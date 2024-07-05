namespace ASPProjectBackend.Models;

public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
    public decimal TotalOrderPrice { get; set; }

    public int ShippingAddressId { get; set; }
    public Address ShippingAddress { get; set; }

    public int BillingAddressId { get; set; }
    public Address BillingAddress { get; set; }

    public ICollection<OrderProduct> Products { get; set; } = [];
}


public enum OrderStatus : byte
{
    Pending = 0,
    Processing = 1,
    Shipped = 2,
    Delivered = 3,
    Cancelled = 4,
    Failed = 5
}