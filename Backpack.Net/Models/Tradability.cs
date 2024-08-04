using System.Text.Json.Serialization;

namespace Backpack.Net
{
    internal sealed class Tradability
    {
        [JsonPropertyName("Craftable")]
        [JsonInclude]
        internal object Craftable { get; init; } = null!;

        [JsonPropertyName("Non-Craftable")]
        [JsonInclude]
        internal object NonCraftable { get; init; } = null!;
    }
}