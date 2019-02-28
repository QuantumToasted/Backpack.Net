using System.Collections.Immutable;
using Newtonsoft.Json;

namespace Backpack.Net
{
    internal sealed class PriceHistoryResponse : BackpackResponse
    {
        [JsonProperty("history")]
        internal ImmutableArray<Price> Prices { get; private set; }
    }
}