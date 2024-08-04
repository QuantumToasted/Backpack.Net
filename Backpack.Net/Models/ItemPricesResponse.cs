using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    internal sealed class ItemPricesResponse : BackpackResponse
    {
        // As of writing (8/4/2024), backpack.tf's item price API returns an "Unknown Item" with no defindexes
        private static readonly string[] IgnoredItems = { "Unknown Item" };
        
        [JsonPropertyName("items")]
        [JsonInclude]
        private object _items = null!;

        [JsonPropertyName("current_time")]
        [JsonInclude]
        internal int CurrentTime { get; init; }

        [JsonPropertyName("raw_usd_value")]
        [JsonInclude]
        internal decimal RawUSDValue { get; init; }

        [JsonPropertyName("usd_currency")]
        [JsonInclude]
        internal string USDCurrency { get; init; } = null!;

        [JsonPropertyName("usd_currency_index")]
        [JsonInclude]
        internal int USDCurrencyIndex { get; init; }

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
                    var dict = JsonSerializer.Deserialize<Dictionary<string, Item>>(json, BackpackClient.JsonOptions)!;
                    foreach (var ignoredItem in IgnoredItems)
                    {
                        dict.Remove(ignoredItem);
                    }

                    return dict;
                }
                catch // failed to deserialize, must be []
                {
                    return new Dictionary<string, Item>();
                }
            } 
        }
    }
}