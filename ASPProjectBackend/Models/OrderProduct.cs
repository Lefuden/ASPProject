using System.ComponentModel.DataAnnotations;

namespace ASPProjectBackend.Models;

public class OrderProduct
{
    public int OrderProductId { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Range(1, byte.MaxValue, ErrorMessage = "Quantity must be atleast 1.")]
    public byte Quantity { get; set; }

    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
