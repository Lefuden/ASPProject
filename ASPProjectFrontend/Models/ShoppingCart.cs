namespace ASPProjectFrontend.Models;

public class ShoppingCart
{
    public int UserId { get; set; }
    public ICollection<Game> Products { get; set; } = [];
}
