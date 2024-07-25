namespace ASPProjectFrontend.Models;

public class ShoppingCart
{
    public int UserId { get; set; }
    public List<int> Products { get; set; } = [];
}
