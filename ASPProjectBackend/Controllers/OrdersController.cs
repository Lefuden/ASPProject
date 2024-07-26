using ASPProjectBackend.Data;
using ASPProjectBackend.Models;
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

			//var orderDtoList = orders.Select(OrderToDto).ToList();
			return orders;
		}

		// PUT: api/Orders/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("Edit")]
		public async Task<IActionResult> PutOrder([FromBody] Order order)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}

			context.Update(order);

			try
			{
				await context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!OrderExists(order.OrderId))
				{
					return NotFound();
				}
			}

			return Ok("Order successfully updated");
		}

		// POST: api/Orders
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Order>> PostOrder([FromBody] Order order)
		{
			context.Orders.Add(order);
			await context.SaveChangesAsync();

			return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
		}

		// DELETE: api/Orders/5
		[HttpDelete("Delete/{id}")]
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

		//private static OrderDto OrderToDto(Order order) => new()
		//{
		//    OrderId = order.OrderId,
		//    OrderDate = order.OrderDate,
		//    OrderStatus = order.OrderStatus,
		//    TotalOrderPrice = order.TotalOrderPrice,
		//    ShippingAddress = order.ShippingAddress,
		//    BillingAddress = order.BillingAddress,
		//    Products = order.Products
		//};
	}
}
