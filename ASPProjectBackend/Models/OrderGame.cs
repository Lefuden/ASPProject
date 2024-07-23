using System.ComponentModel.DataAnnotations;

namespace ASPProjectBackend.Models;

public class OrderGame
{
    public int OrderGameId { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }

    [Range(1, byte.MaxValue, ErrorMessage = "Quantity must be atleast 1.")]
    public byte Quantity { get; set; }

    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
