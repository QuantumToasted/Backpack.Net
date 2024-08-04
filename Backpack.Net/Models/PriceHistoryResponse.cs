using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    internal sealed class PriceHistoryResponse : BackpackResponse
    {
        [JsonPropertyName("history")]
        [JsonInclude]
        internal IReadOnlyList<Price> Prices { get; init; } = null!;
    }
}