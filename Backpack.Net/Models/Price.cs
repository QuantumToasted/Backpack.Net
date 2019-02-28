using System;
using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a model of an item's price.
    /// </summary>
    public sealed class Price
    {
        internal Price()
        { }

        /// <summary>
        /// The value of this item, as a multiple of <see cref="Currency"/>.
        /// <para/> If <see cref="HighValue"/> is set, this is the lower bound of the average price of the item.
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Value { get; private set; }

        /// <summary>
        /// The upper bound of the average price of the item.
        /// </summary>
        [JsonProperty("value_high")]
        public decimal? HighValue { get; private set; }

        /// <summary>
        /// If set, this is the average price of the item in the lowest currency.
        /// If <see cref="HighRawValue"/> is set, this is the lower bound of the average price of the item in the lowest currency.
        /// </summary>
        [JsonProperty("value_raw")]
        public decimal? RawValue { get; private set; }

        /// <summary>
        /// If set, this is the upper bound of the average price of the item in the lowest currency.
        /// </summary>
        [JsonProperty("value_raw_high")]
        public decimal? HighRawValue { get; private set; }

        /// <summary>
        /// The type of currency this item's <see cref="Value"/> is a multiple of.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; private set; }

        /// <summary>
        /// The difference in price from the previous price entry in the lowest currency.
        /// </summary>
        [JsonProperty("difference", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Difference { get; private set; }

        /// <summary>
        /// The last time this price entry was updated.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset LastUpdate => BackpackClient.UnixEpoch.AddSeconds(_lastUpdate);

        [JsonProperty("last_update", NullValueHandling = NullValueHandling.Ignore)]
        private readonly long _lastUpdate;

        /// <summary>
        /// Whether or not this price entry is for an Australium weapon.
        /// </summary>
        [JsonProperty("australium")]
        public bool IsAustralium { get; private set; }
    }
}