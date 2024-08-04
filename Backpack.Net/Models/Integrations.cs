using System.Text.Json.Serialization;

namespace Backpack.Net
{
    internal sealed class Integrations
    {
        [JsonPropertyName("group_member")]
        [JsonInclude]
        public bool IsGroupMember { get; init; }

        [JsonPropertyName("marketplace_seller")]
        [JsonInclude]
        public bool IsMarketplaceSeller { get; init; }

        [JsonPropertyName("automatic")]
        [JsonInclude]
        public bool IsAutomatic { get; init; }

        [JsonPropertyName("steamrep_admin")]
        [JsonInclude]
        public bool IsSteamRepAdmin { get; init; }
    }
}