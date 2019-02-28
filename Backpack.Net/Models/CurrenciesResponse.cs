using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backpack.Net
{
    internal sealed class CurrenciesResponse : BackpackResponse
    {
        [JsonProperty("name")]
        internal string Name { get; private set; }

        [JsonProperty("url")]
        internal string Url { get; private set; }

        [JsonProperty("currencies")]
        internal Dictionary<string, Currency> Currencies { get; private set; }
    }
}