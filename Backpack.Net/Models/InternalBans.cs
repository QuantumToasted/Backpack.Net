using Newtonsoft.Json;

namespace Backpack.Net
{
    internal sealed class InternalBans
    {
        [JsonProperty("steamrep_scammer")]
        internal bool IsSteamRepScammer { get; private set; }

        [JsonProperty("steamrep_caution")]
        internal bool IsSteamRepCaution { get; private set; }

        [JsonProperty("valve")]
        internal ValveBans Valve { get; private set; } = new ValveBans();

        [JsonProperty("all")]
        internal SiteBan All { get; private set; }

        [JsonProperty("suggestions")]
        internal SiteBan Suggestions { get; private set; }

        [JsonProperty("comments")]
        internal SiteBan Comments { get; private set; }

        [JsonProperty("trust")]
        internal SiteBan Trust { get; private set; }

        [JsonProperty("issues")]
        internal SiteBan Issues { get; private set; }

        [JsonProperty("classifieds")]
        internal SiteBan Classifieds { get; private set; }

        [JsonProperty("customizations")]
        internal SiteBan Customizations { get; private set; }

        [JsonProperty("reports")]
        internal SiteBan Reports { get; private set; }
    }
}