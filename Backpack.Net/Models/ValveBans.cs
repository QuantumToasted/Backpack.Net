using System.Text.Json.Serialization;

namespace Backpack.Net
{
    internal sealed class ValveBans
    {
        [JsonPropertyName("economy")]
        [JsonInclude]
        internal bool IsEconomyBanned { get; init; }

        [JsonPropertyName("community")]
        [JsonInclude]
        internal bool IsCommunityBanned { get; init; }

        [JsonPropertyName("vac")]
        [JsonInclude]
        internal bool IsVACBanned { get; init; }

        [JsonPropertyName("game")]
        [JsonInclude]
        internal bool IsGameBanned { get; init; }
    }
}