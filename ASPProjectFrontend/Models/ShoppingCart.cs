namespace ASPProjectFrontend.Models;

public class ShoppingCart
{
    public int UserId { get; set; }
    public ICollection<Product> Products { get; set; } = [];
}
