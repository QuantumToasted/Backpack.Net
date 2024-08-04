using System;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a model of an item's price.
    /// </summary>
    public sealed class Price
    {
        [JsonConstructor]
        internal Price()
        { }

        /// <summary>
        /// The value of this item, as a multiple of <see cref="Currency"/>.
        /// <para/> If <see cref="HighValue"/> is set, this is the lower bound of the average price of the item.
        /// </summary>
        [JsonIgnore]
        public decimal Value => _value.GetValueOrDefault();

        [JsonPropertyName("value")]
        [JsonInclude]
        private decimal? _value;

        /// <summary>
        /// The upper bound of the average price of the item.
        /// </summary>
        [JsonPropertyName("value_high")]
        public decimal? HighValue { get; init; }

        /// <summary>
        /// If set, this is the average price of the item in the lowest currency.
        /// If <see cref="HighRawValue"/> is set, this is the lower bound of the average price of the item in the lowest currency.
        /// </summary>
        [JsonPropertyName("value_raw")]
        public decimal? RawValue { get; init; }

        /// <summary>
        /// If set, this is the upper bound of the average price of the item in the lowest currency.
        /// </summary>
        [JsonPropertyName("value_raw_high")]
        public decimal? HighRawValue { get; init; }

        /// <summary>
        /// The type of currency this item's <see cref="Value"/> is a multiple of.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; init; } = null!;

        /// <summary>
        /// The difference in price from the previous price entry in the lowest currency.
        /// </summary>
        [JsonIgnore]
        public decimal Difference => _difference.GetValueOrDefault();

        [JsonPropertyName("difference")]
        [JsonInclude]
        private decimal? _difference;

        /// <summary>
        /// The last time this price entry was updated.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset LastUpdate => BackpackClient.UnixEpoch.AddSeconds(_lastUpdate.GetValueOrDefault());

        [JsonPropertyName("last_update")]
        [JsonInclude]
        private long? _lastUpdate;

        /// <summary>
        /// Whether or not this price entry is for an Australium weapon.
        /// </summary>
        [JsonPropertyName("australium")]
        public bool IsAustralium { get; init; }
    }
}