using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backpack.Net
{
    internal sealed class ItemPricesResponse : BackpackResponse
    {
        [JsonProperty("current_time")]
        internal int CurrentTime { get; private set; }

        [JsonProperty("raw_usd_value")]
        internal decimal RawUSDValue { get; private set; }

        [JsonProperty("usd_currency")]
        internal string USDCurrency { get; private set; }

        [JsonProperty("usd_currency_index")]
        internal int USDCurrencyIndex { get; private set; }

        [JsonProperty("items")]
        internal Dictionary<string, Item> Items { get; private set; }
    }
}