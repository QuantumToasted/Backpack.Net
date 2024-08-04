using System;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents an in-game currency.
    /// </summary>
    public sealed class Currency
    {
        [JsonConstructor]
        internal Currency()
        { }

        /// <summary>
        /// The in-game name for this currency.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        /// <summary>
        /// The <see cref="Net.Quality"/> for this currency.
        /// </summary>
        [JsonPropertyName("quality")]
        public Quality Quality { get; init; }

        /// <summary>
        /// The <see cref="Net.PriceIndex"/> for this item.
        /// </summary>
        [JsonIgnore]
        public PriceIndex PriceIndex => PriceIndex.Create(Name, Quality, _priceIndex);

        [JsonPropertyName("priceindex")]
        [JsonInclude]
        private string _priceIndex = null!;

        /// <summary>
        /// The singular noun form of this currency as displayed for prices.
        /// </summary>
        [JsonPropertyName("single")]
        public string SingularForm { get; init; } = null!;

        /// <summary>
        /// The plural noun form of this currency as displayed for prices.
        /// </summary>
        [JsonPropertyName("plural")]
        public string PluralForm { get; init; } = null!;

        /// <summary>
        /// The number of decimal places to round this currency's <see cref="Price"/> value to.
        /// </summary>
        [JsonPropertyName("round")]
        public int RoundTo { get; init; }

        /// <summary>
        /// Whether or not the currency is a price blanket.
        /// </summary>
        [JsonPropertyName("blanket")]
        public bool IsPriceBlanket { get; init; }

        /// <summary>
        /// Whether or not this currency is craftable.
        /// </summary>
        [JsonIgnore]
        public bool IsCraftable => _craftable.Equals("Craftable", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// The item definition index for this currency.
        /// </summary>
        [JsonPropertyName("defindex")]
        public int DefinitionIndex { get; init; }

        [JsonPropertyName("craftable")]
        [JsonInclude]
        private string _craftable = null!;

        /// <summary>
        /// The <see cref="Net.Price"/> model for this currency.
        /// </summary>
        [JsonPropertyName("price")]
        public Price Price { get; init; } = null!;
    }
}