using Newtonsoft.Json;
namespace ASPProjectBackend.Models.DTO;
internal class Sub
{
    [JsonProperty("packageid")]
    public string Packageid { get; set; }

    [JsonProperty("percent_savings_text")]
    public string PercentSavingsText { get; set; }

    [JsonProperty("percent_savings")]
    public uint PercentSavings { get; set; }

    [JsonProperty("option_text")]
    public string OptionText { get; set; }

    [JsonProperty("option_description")]
    public string OptionDescription { get; set; }

    [JsonProperty("can_get_free_license")]
    public string CanGetFreeLicense { get; set; }

    [JsonProperty("is_free_license")]
    public bool IsFreeLicense { get; set; }

    [JsonProperty("price_in_cents_with_discount")]
    public uint PriceInCentsWithDiscount { get; set; }
}

internal class PackageGroup
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("selection_text")]
    public string SelectionText { get; set; }

    [JsonProperty("save_text")]
    public string SaveText { get; set; }

    [JsonProperty("display_type")]
    public uint DisplayType { get; set; }

    [JsonProperty("is_recurring_subscription")]
    public string IsRecurringSubscription { get; set; }

    [JsonProperty("subs")]
    public Sub[] Subs { get; set; }
}

internal class Platforms
{
    [JsonProperty("windows")]
    public bool Windows { get; set; }

    [JsonProperty("mac")]
    public bool Mac { get; set; }

    [JsonProperty("linux")]
    public bool Linux { get; set; }
}

internal class Metacritic
{
    [JsonProperty("score")]
    public uint Score { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}

internal class Category
{
    [JsonProperty("id")]
    public uint Id { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}

internal class Genre
{
    [JsonProperty("id")]
    public uint Id { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}

internal class Screenshot
{
    [JsonProperty("id")]
    public uint Id { get; set; }

    [JsonProperty("path_thumbnail")]
    public string PathThumbnail { get; set; }

    [JsonProperty("path_full")]
    public string PathFull { get; set; }
}

internal class Webm
{
    [JsonProperty("480")]
    public string Resolution480 { get; set; }

    [JsonProperty("max")]
    public string Max { get; set; }
}

internal class Movie
{
    [JsonProperty("id")]
    public uint Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("thumbnail")]
    public string Thumbnail { get; set; }

    [JsonProperty("webm")]
    public Webm Webm { get; set; }

    [JsonProperty("highlight")]
    public bool Highlight { get; set; }
}

internal class Recommendations
{
    [JsonProperty("total")]
    public uint Total { get; set; }
}

internal class ReleaseDate
{
    [JsonProperty("coming_soon")]
    public bool ComingSoon { get; set; }

    [JsonProperty("date")]
    public string Date { get; set; }
}

internal class SupportInfo
{
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }
}

internal class Price
{
    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("initial")]
    public uint Initial { get; set; }

    [JsonProperty("final")]
    public uint Final { get; set; }

    [JsonProperty("discount_percent")]
    public uint DiscountPercent { get; set; }

    [JsonProperty("initial_formatted")]
    public string InitialFormatted { get; set; }

    [JsonProperty("final_formatted")]
    public string FinalFormatted { get; set; }
}

internal class Data
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("steam_appid")]
    public uint SteamAppid { get; set; }

    [JsonProperty("required_age")]
    public uint RequiredAge { get; set; }

    [JsonProperty("is_free")]
    public bool IsFree { get; set; }

    [JsonProperty("controller_support")]
    public string ControllerSupport { get; set; }

    [JsonProperty("dlc")]
    public uint[] Dlc { get; set; }

    [JsonProperty("detailed_description")]
    public string DetailedDescription { get; set; }

    [JsonProperty("about_the_game")]
    public string AboutTheGame { get; set; }

    [JsonProperty("short_description")]
    public string ShortDescription { get; set; }

    [JsonProperty("supported_languages")]
    public string SupportedLanguages { get; set; }

    [JsonProperty("header_image")]
    public string HeaderImage { get; set; }

    [JsonProperty("website")]
    public string Website { get; set; }

    [JsonProperty("pc_requirements")]
    public dynamic PcRequirements { get; set; }

    [JsonProperty("mac_requirements")]
    public dynamic MacRequirements { get; set; }

    [JsonProperty("linux_requirements")]
    public dynamic LinuxRequirements { get; set; }

    [JsonProperty("developers")]
    public string[] Developers { get; set; }

    [JsonProperty("publishers")]
    public string[] Publishers { get; set; }

    [JsonProperty("price_overview")]
    public Price PriceOverview { get; set; }

    [JsonProperty("packages")]
    public string[] Packages { get; set; }

    [JsonProperty("package_groups")]
    public PackageGroup[] PackageGroups { get; set; }

    [JsonProperty("platforms")]
    public Platforms Platforms { get; set; }

    [JsonProperty("metacritic")]
    public Metacritic Metacritic { get; set; }

    [JsonProperty("categories")]
    public Category[] Categories { get; set; }

    [JsonProperty("genres")]
    public Genre[] Genres { get; set; }

    [JsonProperty("screenshots")]
    public Screenshot[] Screenshots { get; set; }

    [JsonProperty("movies")]
    public Movie[] Movies { get; set; }

    [JsonProperty("recommendations")]
    public Recommendations Recommendations { get; set; }

    [JsonProperty("achievements")]
    public Achievement Achievements { get; set; }

    [JsonProperty("release_date")]
    public ReleaseDate ReleaseDate { get; set; }

    [JsonProperty("support_info")]
    public SupportInfo SupportInfo { get; set; }

    [JsonProperty("background")]
    public string Background { get; set; }

    [JsonProperty("content_descriptors")]
    public ContentDescriptor ContentDescriptors { get; set; }
}

public class ContentDescriptor
{
    [JsonProperty("ids")]
    public uint[] Ids { get; set; }

    [JsonProperty("notes")]
    public string Notes { get; set; }
}

public class Achievement
{
    [JsonProperty("total")]
    public uint Total { get; set; }

    [JsonProperty("highlighted")]
    public Highlighted[] Highlighted { get; set; }
}

public class Highlighted
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("path")]
    public string Path { get; set; }
}

[JsonConverter(typeof(AppDetailsResponseConverter))]
internal class AppDetailsContainer
{
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("data")]
    public Data Data { get; set; }
}

//using Newtonsoft.Json;
//using System.Text.Json.Serialization;

//namespace ASPProjectBackend.Models.DTO;

//public class AppDetailsResponse
//{
//    [JsonProperty("success")]
//    [JsonPropertyName("success")]
//    public bool? Success { get; set; }

//    [JsonProperty("data")]
//    [JsonPropertyName("data")]
//    public Data Data { get; set; }
//}

//public class Achievements
//{
//    [JsonProperty("total")]
//    [JsonPropertyName("total")]
//    public int? Total { get; set; }

//    [JsonProperty("highlighted")]
//    [JsonPropertyName("highlighted")]
//    public List<Highlighted> Highlighted { get; set; }
//}

//public class Category
//{
//    [JsonProperty("id")]
//    [JsonPropertyName("id")]
//    public int? Id { get; set; }

//    [JsonProperty("description")]
//    [JsonPropertyName("description")]
//    public string Description { get; set; }
//}

//public class ContentDescriptors
//{
//    [JsonProperty("ids")]
//    [JsonPropertyName("ids")]
//    public List<int?> Ids { get; set; }

//    [JsonProperty("notes")]
//    [JsonPropertyName("notes")]
//    public string Notes { get; set; }
//}

//public class Data
//{
//    [JsonProperty("type")]
//    [JsonPropertyName("type")]
//    public string Type { get; set; }

//    [JsonProperty("name")]
//    [JsonPropertyName("name")]
//    public string Name { get; set; }

//    [JsonProperty("steam_appid")]
//    [JsonPropertyName("steam_appid")]
//    public int? SteamAppid { get; set; }

//    [JsonProperty("required_age")]
//    [JsonPropertyName("required_age")]
//    public int? RequiredAge { get; set; }

//    [JsonProperty("is_free")]
//    [JsonPropertyName("is_free")]
//    public bool? IsFree { get; set; }

//    [JsonProperty("dlc")]
//    [JsonPropertyName("dlc")]
//    public List<int?> Dlc { get; set; }

//    [JsonProperty("detailed_description")]
//    [JsonPropertyName("detailed_description")]
//    public string DetailedDescription { get; set; }

//    [JsonProperty("about_the_game")]
//    [JsonPropertyName("about_the_game")]
//    public string AboutTheGame { get; set; }

//    [JsonProperty("short_description")]
//    [JsonPropertyName("short_description")]
//    public string ShortDescription { get; set; }

//    [JsonProperty("supported_languages")]
//    [JsonPropertyName("supported_languages")]
//    public string SupportedLanguages { get; set; }

//    [JsonProperty("header_image")]
//    [JsonPropertyName("header_image")]
//    public string HeaderImage { get; set; }

//    [JsonProperty("website")]
//    [JsonPropertyName("website")]
//    public string Website { get; set; }

//    [JsonProperty("pc_requirements")]
//    [JsonPropertyName("pc_requirements")]
//    public PcRequirements PcRequirements { get; set; }

//    [JsonProperty("mac_requirements")]
//    [JsonPropertyName("mac_requirements")]
//    public MacRequirements MacRequirements { get; set; }

//    [JsonProperty("linux_requirements")]
//    [JsonPropertyName("linux_requirements")]
//    public LinuxRequirements LinuxRequirements { get; set; }

//    [JsonProperty("developers")]
//    [JsonPropertyName("developers")]
//    public List<string> Developers { get; set; }

//    [JsonProperty("publishers")]
//    [JsonPropertyName("publishers")]
//    public List<string> Publishers { get; set; }

//    [JsonProperty("packages")]
//    [JsonPropertyName("packages")]
//    public List<int?> Packages { get; set; }

//    [JsonProperty("package_groups")]
//    [JsonPropertyName("package_groups")]
//    public List<PackageGroup> PackageGroups { get; set; }

//    [JsonProperty("platforms")]
//    [JsonPropertyName("platforms")]
//    public Platforms Platforms { get; set; }

//    [JsonProperty("metacritic")]
//    [JsonPropertyName("metacritic")]
//    public Metacritic Metacritic { get; set; }

//    [JsonProperty("categories")]
//    [JsonPropertyName("categories")]
//    public List<Category> Categories { get; set; }

//    [JsonProperty("genres")]
//    [JsonPropertyName("genres")]
//    public List<Genre> Genres { get; set; }

//    [JsonProperty("screenshots")]
//    [JsonPropertyName("screenshots")]
//    public List<Screenshot> Screenshots { get; set; }

//    [JsonProperty("movies")]
//    [JsonPropertyName("movies")]
//    public List<Movie> Movies { get; set; }

//    [JsonProperty("recommendations")]
//    [JsonPropertyName("recommendations")]
//    public Recommendations Recommendations { get; set; }

//    [JsonProperty("achievements")]
//    [JsonPropertyName("achievements")]
//    public Achievements Achievements { get; set; }

//    [JsonProperty("release_date")]
//    [JsonPropertyName("release_date")]
//    public ReleaseDate ReleaseDate { get; set; }

//    [JsonProperty("support_info")]
//    [JsonPropertyName("support_info")]
//    public SupportInfo SupportInfo { get; set; }

//    [JsonProperty("background")]
//    [JsonPropertyName("background")]
//    public string Background { get; set; }

//    [JsonProperty("content_descriptors")]
//    [JsonPropertyName("content_descriptors")]
//    public ContentDescriptors ContentDescriptors { get; set; }
//}

//public class Genre
//{
//    [JsonProperty("id")]
//    [JsonPropertyName("id")]
//    public string Id { get; set; }

//    [JsonProperty("description")]
//    [JsonPropertyName("description")]
//    public string Description { get; set; }
//}

//public class Highlighted
//{
//    [JsonProperty("name")]
//    [JsonPropertyName("name")]
//    public string Name { get; set; }

//    [JsonProperty("path")]
//    [JsonPropertyName("path")]
//    public string Path { get; set; }
//}

//public class LinuxRequirements
//{
//    [JsonProperty("minimum")]
//    [JsonPropertyName("minimum")]
//    public string Minimum { get; set; }
//}

//public class MacRequirements
//{
//    [JsonProperty("minimum")]
//    [JsonPropertyName("minimum")]
//    public string Minimum { get; set; }
//}

//public class Metacritic
//{
//    [JsonProperty("score")]
//    [JsonPropertyName("score")]
//    public int? Score { get; set; }

//    [JsonProperty("url")]
//    [JsonPropertyName("url")]
//    public string Url { get; set; }
//}

//public class Movie
//{
//    [JsonProperty("id")]
//    [JsonPropertyName("id")]
//    public int? Id { get; set; }

//    [JsonProperty("name")]
//    [JsonPropertyName("name")]
//    public string Name { get; set; }

//    [JsonProperty("thumbnail")]
//    [JsonPropertyName("thumbnail")]
//    public string Thumbnail { get; set; }

//    [JsonProperty("webm")]
//    [JsonPropertyName("webm")]
//    public Webm Webm { get; set; }

//    [JsonProperty("mp4")]
//    [JsonPropertyName("mp4")]
//    public Mp4 Mp4 { get; set; }

//    [JsonProperty("highlight")]
//    [JsonPropertyName("highlight")]
//    public bool? Highlight { get; set; }
//}

//public class Mp4
//{
//    [JsonProperty("480")]
//    [JsonPropertyName("480")]
//    public string _480 { get; set; }

//    [JsonProperty("max")]
//    [JsonPropertyName("max")]
//    public string Max { get; set; }
//}

//public class PackageGroup
//{
//    [JsonProperty("name")]
//    [JsonPropertyName("name")]
//    public string Name { get; set; }

//    [JsonProperty("title")]
//    [JsonPropertyName("title")]
//    public string Title { get; set; }

//    [JsonProperty("description")]
//    [JsonPropertyName("description")]
//    public string Description { get; set; }

//    [JsonProperty("selection_text")]
//    [JsonPropertyName("selection_text")]
//    public string SelectionText { get; set; }

//    [JsonProperty("save_text")]
//    [JsonPropertyName("save_text")]
//    public string SaveText { get; set; }

//    [JsonProperty("display_type")]
//    [JsonPropertyName("display_type")]
//    public int? DisplayType { get; set; }

//    [JsonProperty("is_recurring_subscription")]
//    [JsonPropertyName("is_recurring_subscription")]
//    public string IsRecurringSubscription { get; set; }

//    [JsonProperty("subs")]
//    [JsonPropertyName("subs")]
//    public List<Sub> Subs { get; set; }
//}

//public class PcRequirements
//{
//    [JsonProperty("minimum")]
//    [JsonPropertyName("minimum")]
//    public string Minimum { get; set; }

//    [JsonProperty("recommended")]
//    [JsonPropertyName("recommended")]
//    public string Recommended { get; set; }
//}

//public class Platforms
//{
//    [JsonProperty("windows")]
//    [JsonPropertyName("windows")]
//    public bool? Windows { get; set; }

//    [JsonProperty("mac")]
//    [JsonPropertyName("mac")]
//    public bool? Mac { get; set; }

//    [JsonProperty("linux")]
//    [JsonPropertyName("linux")]
//    public bool? Linux { get; set; }
//}

//public class Recommendations
//{
//    [JsonProperty("total")]
//    [JsonPropertyName("total")]
//    public int? Total { get; set; }
//}

//public class ReleaseDate
//{
//    [JsonProperty("coming_soon")]
//    [JsonPropertyName("coming_soon")]
//    public bool? ComingSoon { get; set; }

//    [JsonProperty("date")]
//    [JsonPropertyName("date")]
//    public string Date { get; set; }
//}

//public class Screenshot
//{
//    [JsonProperty("id")]
//    [JsonPropertyName("id")]
//    public int? Id { get; set; }

//    [JsonProperty("path_thumbnail")]
//    [JsonPropertyName("path_thumbnail")]
//    public string PathThumbnail { get; set; }

//    [JsonProperty("path_full")]
//    [JsonPropertyName("path_full")]
//    public string PathFull { get; set; }
//}

//public class Sub
//{
//    [JsonProperty("packageid")]
//    [JsonPropertyName("packageid")]
//    public int? Packageid { get; set; }

//    [JsonProperty("percent_savings_text")]
//    [JsonPropertyName("percent_savings_text")]
//    public string PercentSavingsText { get; set; }

//    [JsonProperty("percent_savings")]
//    [JsonPropertyName("percent_savings")]
//    public int? PercentSavings { get; set; }

//    [JsonProperty("option_text")]
//    [JsonPropertyName("option_text")]
//    public string OptionText { get; set; }

//    [JsonProperty("option_description")]
//    [JsonPropertyName("option_description")]
//    public string OptionDescription { get; set; }

//    [JsonProperty("can_get_free_license")]
//    [JsonPropertyName("can_get_free_license")]
//    public string CanGetFreeLicense { get; set; }

//    [JsonProperty("is_free_license")]
//    [JsonPropertyName("is_free_license")]
//    public bool? IsFreeLicense { get; set; }

//    [JsonProperty("price_in_cents_with_discount")]
//    [JsonPropertyName("price_in_cents_with_discount")]
//    public int? PriceInCentsWithDiscount { get; set; }
//}

//public class SupportInfo
//{
//    [JsonProperty("url")]
//    [JsonPropertyName("url")]
//    public string Url { get; set; }

//    [JsonProperty("email")]
//    [JsonPropertyName("email")]
//    public string Email { get; set; }
//}

//public class Webm
//{
//    [JsonProperty("480")]
//    [JsonPropertyName("480")]
//    public string _480 { get; set; }

//    [JsonProperty("max")]
//    [JsonPropertyName("max")]
//    public string Max { get; set; }
//}

