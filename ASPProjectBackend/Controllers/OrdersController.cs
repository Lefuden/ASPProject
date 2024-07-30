using ASPProjectBackend.Data;
using ASPProjectBackend.Models;
using ASPProjectBackend.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPProjectBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController(ApplicationDbContext context) : ControllerBase
	{
		// GET: api/Orders
		[Authorize(Roles = "Admin")]
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
		{
			return await context.Orders.ToListAsync();
		}

		// GET: api/Orders/5
		[Authorize(Roles = "Admin,User")]
		[HttpGet("{id}")]
		public async Task<ActionResult<Order>> GetOrder(int id)
		{
			var order = await context.Orders.FindAsync(id);

			if (order == null)
			{
				return NotFound();
			}

			return order;
		}

		[HttpGet("User/{id}")]
		public async Task<ActionResult<IEnumerable<Order>>> GetAllUserOrders(int? userId)
		{
			if (userId == null)
			{
				Console.WriteLine("User not found");
				return NotFound();
			}

			var orders = await context.Orders
				.Include(o => o.User)
					.ThenInclude(u => u.Address)
				.Where(o => o.UserId == userId)
				.ToListAsync();

			if (orders.Count == 0)
			{
				Console.WriteLine("Orders not found");
				return NotFound();
			}

			return orders;
		}

		[HttpPost("Checkout")]
		public async Task<IActionResult> Checkout([FromBody] CheckoutDto checkoutDto)
		{

			List<Game> games = new();
			List<GameDto> gamestoDto = new();

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

			gamestoDto = new List<GameDto>(games.Select(GameToDto).ToList());
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

		private static GameDto GameToDto(Game game) => new()
		{
			Id = game.Id,
			Name = game.Name,
			SteamAppId = game.SteamAppId,
			AboutTheGame = game.AboutTheGame,
			ShortDescription = game.ShortDescription,
			HeaderImage = game.HeaderImage,
			Website = game.Website,
			Developers = game.Developers,
			Publishers = game.Publishers,
			Genres = game.Genres,
			Screenshots = game.Screenshots,
			MetacriticScore = game.MetacriticScore,
			ReleaseDate = game.ReleaseDate,
			InitialPrice = game.InitialPrice,
			DiscountPercent = game.DiscountPercent,
			Stock = game.Stock
		};
	}
}
