namespace ASPProjectBackend.Models;

public class ShoppingCart
{
    public int ShoppingCartId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
}
