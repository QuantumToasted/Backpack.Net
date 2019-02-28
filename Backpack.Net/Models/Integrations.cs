using Newtonsoft.Json;

namespace Backpack.Net
{
    internal sealed class Integrations
    {
        [JsonProperty("group_member")]
        internal bool IsGroupMember { get; private set; }

        [JsonProperty("marketplace_seller")]
        internal bool IsMarketplaceSeller { get; private set; }

        [JsonProperty("automatic")]
        internal bool IsAutomatic { get; private set; }

        [JsonProperty("steamrep_admin")]
        internal bool IsSteamRepAdmin { get; private set; }
    }
}