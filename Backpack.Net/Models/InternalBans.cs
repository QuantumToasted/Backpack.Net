using System.Text.Json.Serialization;

namespace Backpack.Net
{
    internal sealed class InternalBans
    {
        [JsonPropertyName("steamrep_scammer")]
        [JsonInclude]
        internal bool IsSteamRepScammer { get; init; }

        [JsonPropertyName("steamrep_caution")]
        [JsonInclude]
        internal bool IsSteamRepCaution { get; init; }

        [JsonPropertyName("valve")]
        [JsonInclude]
        internal ValveBans Valve { get; init; } = null!;

        [JsonPropertyName("all")]
        [JsonInclude]
        internal SiteBan All { get; init; } = null!;

        [JsonPropertyName("suggestions")]
        [JsonInclude]
        internal SiteBan Suggestions { get; init; } = null!;

        [JsonPropertyName("comments")]
        [JsonInclude]
        internal SiteBan Comments { get; init; } = null!;

        [JsonPropertyName("trust")]
        [JsonInclude]
        internal SiteBan Trust { get; init; } = null!;

        [JsonPropertyName("issues")]
        [JsonInclude]
        internal SiteBan Issues { get; init; } = null!;

        [JsonPropertyName("classifieds")]
        [JsonInclude]
        internal SiteBan Classifieds { get; init; } = null!;

        [JsonPropertyName("customizations")]
        [JsonInclude]
        internal SiteBan Customizations { get; init; } = null!;

        [JsonPropertyName("reports")]
        [JsonInclude]
        internal SiteBan Reports { get; init; } = null!;
    }
}