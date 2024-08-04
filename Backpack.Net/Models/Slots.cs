using System.Text.Json.Serialization;

namespace Backpack.Net
{
    internal sealed class Slots
    {
        [JsonPropertyName("used")]
        [JsonInclude]
        internal int Used { get; init; }

        [JsonPropertyName("total")]
        [JsonInclude]
        internal int Total { get; init; }
    }
}