using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backpack.Net
{
    internal sealed class ItemPricesResponse : BackpackResponse
    {
        [JsonProperty("items")]
        private object _items;

        [JsonProperty("current_time")]
        internal int CurrentTime { get; private set; }

        [JsonProperty("raw_usd_value")]
        internal decimal RawUSDValue { get; private set; }

        [JsonProperty("usd_currency")]
        internal string USDCurrency { get; private set; }

        [JsonProperty("usd_currency_index")]
        internal int USDCurrencyIndex { get; private set; }

        [JsonIgnore]
        internal Dictionary<string, Item> Items 
        { 
            get 
            {
                if (_items is null)
                    return new Dictionary<string, Item>();

                var json = _items.ToString();

                try
                {
                    return JsonConvert.DeserializeObject<Dictionary<string, Item>>(json);
                }
                catch // failed to deserialize, must be []
                {
                    return new Dictionary<string, Item>();
                }
            } 
        }
    }
}