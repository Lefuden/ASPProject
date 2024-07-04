using System.ComponentModel.DataAnnotations;

namespace ASPProjectBackend.Models;

public class ShoppingCartProduct
{
    [Key]
    public int ShoppingCartProductId { get; set; }
    public int ShoppingCartId { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public byte Quantity { get; set; }
}
