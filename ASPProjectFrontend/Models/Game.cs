namespace ASPProjectFrontend.Models;

public class Game
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public uint? SteamAppId { get; set; }
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
    public float? DiscountPercent { get; set; }
}