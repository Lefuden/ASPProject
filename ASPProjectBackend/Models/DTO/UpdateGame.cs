namespace ASPProjectBackend.Models.DTO;

public class UpdateGame
{
    //public int Id { get; set; }
    public string Name { get; set; }
    public string? ShortDescription { get; set; }
    public uint InitialPrice { get; set; }
    public float DiscountPercent { get; set; }
}
