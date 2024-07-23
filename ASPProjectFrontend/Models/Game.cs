using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPProjectFrontend.Models;

public class Game
{
    public int Id { get; set; }

    [DisplayName("Product Name")]
    public string Name { get; set; }
    public uint SteamAppId { get; set; }
    public string? AboutTheGame { get; set; }
    public string? ShortDescription { get; set; }
    public string? HeaderImage { get; set; }
    public string? Website { get; set; }
    public string? Developers { get; set; }
    public string? Publishers { get; set; }
    public string? Genres { get; set; }
    public string? Screenshots { get; set; }
    public uint? MetacriticScore { get; set; }
    public string? ReleaseDate { get; set; }
    public uint? InitialPrice { get; set; }

    [Range(0, 2, ErrorMessage = "Discount must be between 0 and 2")]
    public float DiscountPercent { get; set; } = 1.00f;

    [DisplayName("Amount In Stock")]
    [Range(0, 255, ErrorMessage = "Stock must be between 0 and 255")]
    public byte Stock { get; set; }
}
