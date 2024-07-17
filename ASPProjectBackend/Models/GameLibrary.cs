using ASPProjectBackend.Data.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASPProjectBackend.Models;

public class GameLibrary
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Key]
    [JsonPropertyName("steam_appid")]
    public long SteamAppid { get; set; }

    [JsonPropertyName("required_age")]
    [JsonConverter(typeof(RequiredAgeConverter))]
    public string RequiredAge { get; set; }

    [JsonPropertyName("is_free")]
    public bool IsFree { get; set; }

    [JsonPropertyName("controller_support")]
    public string ControllerSupport { get; set; }

    [JsonPropertyName("detailed_description")]
    public string DetailedDescription { get; set; }

    [JsonPropertyName("about_the_game")]
    public string AboutTheGame { get; set; }

    [JsonPropertyName("short_description")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("supported_languages")]
    public string SupportedLanguages { get; set; }

    [JsonPropertyName("header_image")]
    public Uri HeaderImage { get; set; }

    [JsonPropertyName("capsule_image")]
    public Uri CapsuleImage { get; set; }

    [JsonPropertyName("capsule_imagev5")]
    public Uri CapsuleImagev5 { get; set; }

    [JsonPropertyName("website")]
    public Uri Website { get; set; }

    [JsonPropertyName("pc_requirements")]
    [JsonConverter(typeof(RequirementsConverter))]
    public RequirementsObject PcRequirements { get; set; }

    [JsonPropertyName("mac_requirements")]
    [JsonConverter(typeof(RequirementsConverter))]
    public RequirementsObject MacRequirements { get; set; }

    [JsonPropertyName("linux_requirements")]
    [JsonConverter(typeof(RequirementsConverter))]
    public RequirementsObject LinuxRequirements { get; set; }

    [JsonPropertyName("price_overview")]
    public PriceOverview PriceOverview { get; set; }

    [JsonPropertyName("metacritic")]
    public Metacritic Metacritic { get; set; }

    [JsonPropertyName("genres")]
    public List<Genre> Genres { get; set; }

    [JsonPropertyName("release_date")]
    public ReleaseDate ReleaseDate { get; set; }
}

public class Genre
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

public class RequirementsWrapper
{
    public RequirementsObject RequirementsObject { get; set; }
    public bool IsEmptyArray { get; set; }
}

public class RequirementsObject
{
    [JsonPropertyName("minimum")]
    public string Minimum { get; set; }

    [JsonPropertyName("recommended")]
    public string Recommended { get; set; }
}

//public class PcRequirements
//{
//    [JsonPropertyName("minimum")]
//    public string Minimum { get; set; }

//    [JsonPropertyName("recommended")]
//    public string Recommended { get; set; }
//}

//public class MacRequirements
//{
//    [JsonPropertyName("minimum")]
//    public string Minimum { get; set; }

//    [JsonPropertyName("recommended")]
//    public string Recommended { get; set; }
//}

//public class LinuxRequirements
//{
//    [JsonPropertyName("minimum")]
//    public string Minimum { get; set; }

//    [JsonPropertyName("recommended")]
//    public string Recommended { get; set; }
//}

public class Metacritic
{
    [JsonPropertyName("score")]
    public long Score { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }
}

public class PriceOverview
{
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("initial")]
    public long Initial { get; set; }

    [JsonPropertyName("final")]
    public long Final { get; set; }

    [JsonPropertyName("discount_percent")]
    public long DiscountPercent { get; set; }

    [JsonPropertyName("initial_formatted")]
    public string InitialFormatted { get; set; }

    [JsonPropertyName("final_formatted")]
    public string FinalFormatted { get; set; }
}

public class ReleaseDate
{
    [JsonPropertyName("coming_soon")]
    public bool ComingSoon { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }
}

public class GameData
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("data")]
    public GameLibrary Data { get; set; }
}
