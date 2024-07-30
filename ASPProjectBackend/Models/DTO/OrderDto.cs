namespace ASPProjectBackend.Models.DTO;

public class OrderDto
{
	public int OrderId { get; set; }
	public User User { get; set; }
	public DateTime OrderDate { get; set; } = DateTime.Now;
	public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
	public decimal TotalOrderPrice { get; set; }
	public Address ShippingAddress { get; set; }
	public Address BillingAddress { get; set; }
	public ICollection<GameDto> Games { get; set; } = [];
}