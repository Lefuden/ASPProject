using System.ComponentModel.DataAnnotations;

namespace ASPProjectFrontend.Models.DTO;

public class UpdateGame
{
    //public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string ShortDescription { get; set; }

    [Required]
    public uint InitialPrice { get; set; }
    public float DiscountPercent { get; set; } = 0;
}
