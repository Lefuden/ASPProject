using ASPProjectBackend.Data;
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
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            var orders = await context.Orders.ToListAsync();
            var orderDtoList = orders.Select(OrderToDto).ToList();

            return orderDtoList;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return OrderToDto(order);
        }

        [HttpGet("User/{id}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllUserOrders(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("User not found");
                return NotFound();
            }

            var order = await context.Orders
                .Include(u => u.User)
                .Where(u => u.UserId == u.User.Id && u.UserId == id)
                .ToListAsync();

            if (order == null)
            {
                Console.WriteLine("Orders not found");
                return NotFound();
            }

            var orderDtoList = order.Select(OrderToDto).ToList();
            return orderDtoList;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            context.Entry(order).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            context.Orders.Remove(order);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return context.Orders.Any(e => e.OrderId == id);
        }

        private static OrderDto OrderToDto(Order order) => new()
        {
            OrderId = order.OrderId,
            OrderDate = order.OrderDate,
            OrderStatus = order.OrderStatus,
            TotalOrderPrice = order.TotalOrderPrice,
            ShippingAddress = order.ShippingAddress,
            BillingAddress = order.BillingAddress,
            Products = order.Products
        };
    }
}
