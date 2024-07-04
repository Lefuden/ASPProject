using System.ComponentModel.DataAnnotations;

namespace ASPProjectBackend.Models;

public class OrderProduct
{
    [Key]
    public int OrderProductId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public byte Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}
