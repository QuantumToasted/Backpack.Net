using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    internal sealed class CurrenciesResponse : BackpackResponse
    {
        [JsonPropertyName("name")]
        [JsonInclude]
        internal string Name { get; init; } = null!;

        [JsonPropertyName("url")]
        [JsonInclude]
        internal string Url { get; init; } = null!;

        [JsonPropertyName("currencies")]
        [JsonInclude]
        internal Dictionary<string, Currency> Currencies { get; init; } = null!;
    }
}