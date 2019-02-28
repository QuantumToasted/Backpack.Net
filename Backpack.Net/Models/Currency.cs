using System;
using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents an in-game currency.
    /// </summary>
    public sealed class Currency
    {
        internal Currency()
        { }

        /// <summary>
        /// The in-game name for this currency.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// The <see cref="Net.Quality"/> for this currency.
        /// </summary>
        [JsonProperty("quality")]
        public Quality Quality { get; private set; }

        /// <summary>
        /// The <see cref="Net.PriceIndex"/> for this item.
        /// </summary>
        [JsonIgnore]
        public PriceIndex PriceIndex => PriceIndex.Create(Name, Quality, _priceIndex);

        [JsonProperty("priceindex")]
        private readonly string _priceIndex;

        /// <summary>
        /// The singular noun form of this currency as displayed for prices.
        /// </summary>
        [JsonProperty("single")]
        public string SingularForm { get; private set; }

        /// <summary>
        /// The plural noun form of this currency as displayed for prices.
        /// </summary>
        [JsonProperty("plural")]
        public string PluralForm { get; private set; }

        /// <summary>
        /// The number of decimal places to round this currency's <see cref="Price"/> value to.
        /// </summary>
        [JsonProperty("round")]
        public int RoundTo { get; private set; }

        /// <summary>
        /// Whether or not the currency is a price blanket.
        /// </summary>
        [JsonProperty("blanket")]
        public bool IsPriceBlanket { get; private set; }

        /// <summary>
        /// Whether or not this currency is craftable.
        /// </summary>
        [JsonIgnore]
        public bool IsCraftable => _craftable.Equals("Craftable", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// The item definition index for this currency.
        /// </summary>
        [JsonProperty("defindex")]
        public int DefinitionIndex { get; private set; }

        [JsonProperty("craftable")]
        private string _craftable;

        /// <summary>
        /// The <see cref="Net.Price"/> model for this currency.
        /// </summary>
        [JsonProperty("price")]
        public Price Price { get; private set; }
    }
}