namespace ASPProjectFrontend.Models;

public class ShoppingCart
{
	public int UserId { get; set; }
	public List<Game> Products { get; set; } = [];
}
