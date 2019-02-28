using Newtonsoft.Json;

namespace Backpack.Net
{
    internal sealed class ValveBans
    {
        [JsonProperty("economy")]
        internal bool IsEconomyBanned { get; private set; }

        [JsonProperty("community")]
        internal bool IsCommunityBanned { get; private set; }

        [JsonProperty("vac")]
        internal bool IsVACBanned { get; private set; }

        [JsonProperty("game")]
        internal bool IsGameBanned { get; private set; }
    }
}