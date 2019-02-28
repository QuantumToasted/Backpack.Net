using Newtonsoft.Json;

namespace Backpack.Net
{
    internal sealed class Slots
    {
        [JsonProperty("used")]
        internal int Used { get; private set; }

        [JsonProperty("total")]
        internal int Total { get; private set; }
    }
}