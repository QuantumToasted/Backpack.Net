using Newtonsoft.Json;

namespace Backpack.Net
{
    internal sealed class Tradability
    {
        [JsonProperty("Craftable")]
        internal object Craftable { get; private set; }

        [JsonProperty("Non-Craftable")]
        internal object NonCraftable { get; private set; }
    }
}