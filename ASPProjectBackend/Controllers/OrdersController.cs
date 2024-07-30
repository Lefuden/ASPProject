using ASPProjectBackend.Data;
using ASPProjectBackend.Helpers;
using ASPProjectBackend.Models;
using ASPProjectBackend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(ApplicationDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders()
        {
            return await context.Orders
                                .Include(o => o.User)
                                    .ThenInclude(u => u.Address)
                                .Select(order => DtoConverter.OrderToDto(order))
                                .ToListAsync();
        }

        [HttpGet("User/{userId}")]
        public async Task<ActionResult<List<OrderDto>>> GetAllUserOrders(int? userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            var orders = await context.Orders
                .Include(o => o.User)
                    .ThenInclude(u => u.Address)
                .Where(o => o.UserId == userId)
                .Select(order => DtoConverter.OrderToDto(order))
                .ToListAsync();

            return orders;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await context.Orders
                .Include(o => o.User)
                    .ThenInclude(u => u.Address)
                .FirstOrDefaultAsync(order => order.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return DtoConverter.OrderToDto(order);
        }

        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutDto checkoutDto)
        {
            List<Game> games = [];
            List<GameDto> gamestoDto = [];

            foreach (var id in checkoutDto.Games)
            {
                var game = await context.Games.FindAsync(id);

                if (game != null)
                {
                    if (game.Stock > 0)
                    {
                        game.Stock--;
                        games.Add(game);
                    }
                }
            }

            foreach (var game in games)
            {
                context.Update(game);
            }

            await context.SaveChangesAsync();

            var user = await context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == checkoutDto.UserId);

            if (user == null)
            {
                return BadRequest();
            }

            gamestoDto = new List<GameDto>(games.Select(DtoConverter.GameToDto).ToList());
            var order = new Order
            {
                UserId = user.Id,
                User = user,
                TotalOrderPrice = (decimal)games.Sum(tp => tp.DiscountPercent * tp.InitialPrice),
                ShippingAddressId = user.AddressId.Value,
                ShippingAddress = user.Address,
                BillingAddressId = user.AddressId.Value,
                BillingAddress = user.Address,
                Games = games
            };

            await context.AddAsync(order);
            await context.SaveChangesAsync();

            return Ok(gamestoDto);
        }
    }
}
