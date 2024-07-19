namespace ASPProjectBackend.Models;
public class Game
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }
    public uint? SteamAppId { get; set; }
    public uint? RequiredAge { get; set; }
    public bool? IsFree { get; set; }
    public string? DetailedDescription { get; set; }
    public string? AboutTheGame { get; set; }
    public string? ShortDescription { get; set; }
    public string? SupportedLanguages { get; set; }
    public string? HeaderImage { get; set; }
    public string? Website { get; set; }
    public string? PcRequirements { get; set; }
    public string? MacRequirements { get; set; }
    public string? LinuxRequirements { get; set; }
    public string? Developers { get; set; }
    public string? Publishers { get; set; }
    public string? Categories { get; set; }
    public string? Genres { get; set; }
    public string? Screenshots { get; set; }
    public string? Movies { get; set; }
    public string? Platforms { get; set; }
    public uint? MetacriticScore { get; set; }
    public string? MetacriticUrl { get; set; }
    public uint? TotalRecommendations { get; set; }
    public uint? TotalAchievements { get; set; }
    public string? ReleaseDate { get; set; }
    public bool? ComingSoon { get; set; }
    public string? SupportInfo { get; set; }
    public string? Background { get; set; }
    public string? ContentDescriptors { get; set; }
}
