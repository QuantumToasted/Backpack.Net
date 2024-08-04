using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a particular collection of <see cref="Price"/>s for an item, sorted by craftability.
    /// </summary>
    public sealed class ItemPrice
    {
        [JsonConstructor]
        internal ItemPrice()
        { }

        [JsonIgnore]
        private string _name = null!;

        [JsonIgnore]
        private Quality _quality;

        internal ItemPrice WithName(string name)
        {
            _name = name;
            return this;
        }

        internal ItemPrice WithQuality(Quality quality)
        {
            _quality = quality;
            return this;
        }

        /// <summary>
        /// Craftable <see cref="Price"/>s for this item.
        /// </summary>
        [JsonIgnore]
        public Dictionary<PriceIndex, Price> Craftable
        {
            get
            {
                if (Tradable.Craftable is null)
                    return new Dictionary<PriceIndex, Price>();

                var json = Tradable.Craftable.ToString();

                try
                {
                    var dict = JsonSerializer.Deserialize<Dictionary<string, Price>>(json, BackpackClient.JsonOptions)!;
                    return dict.ToDictionary(x => PriceIndex.Create(_name, _quality, x.Key), x => x.Value);
                }
                catch
                {
                    var list = JsonSerializer.Deserialize<List<Price>>(json, BackpackClient.JsonOptions)!;
                    return new Dictionary<PriceIndex, Price>
                    {
                        { new DefaultPriceIndex(), list[0] }
                    };
                }
            }
        }

        /// <summary>
        /// Non-craftable <see cref="Price"/>s for this item.
        /// </summary>
        [JsonIgnore]
        public Dictionary<PriceIndex, Price> NonCraftable
        {
            get
            {
                if (Tradable.NonCraftable is null)
                    return new Dictionary<PriceIndex, Price>();

                var json = Tradable.NonCraftable.ToString();

                try
                {
                    var dict = JsonSerializer.Deserialize<Dictionary<string, Price>>(json, BackpackClient.JsonOptions);
                    return dict.ToDictionary(x => PriceIndex.Create(_name, _quality, x.Key), x => x.Value);
                }
                catch
                {
                    var list = JsonSerializer.Deserialize<List<Price>>(json, BackpackClient.JsonOptions)!;
                    return new Dictionary<PriceIndex, Price>
                    {
                        { new DefaultPriceIndex(), list[0] }
                    };
                }
            }
        }

        [JsonPropertyName("Tradable")]
        [JsonInclude]
        internal Tradability Tradable { get; init; } = null!;
    }
}