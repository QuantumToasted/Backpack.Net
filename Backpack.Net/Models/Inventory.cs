using System;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="BackpackUser"/>'s inventory.
    /// </summary>
    public sealed class Inventory
    {
        [JsonConstructor]
        internal Inventory()
        { }

        /// <summary>
        /// This inventory's ranking on backpack.tf.
        /// </summary>
        [JsonPropertyName("ranking")]
        public int Ranking { get; init; }

        /// <summary>
        /// This inventory's value, in the lowest currency.
        /// </summary>
        [JsonPropertyName("value")]
        public decimal Value { get; init; }

        /// <summary>
        /// The last time this inventory was updated.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset LastUpdated => BackpackClient.UnixEpoch.AddSeconds(_lastUpdate);

        /// <summary>
        /// The amount of raw metal (refined) this inventory contains.
        /// </summary>
        [JsonPropertyName("metal")]
        public decimal Metal { get; init; }

        /// <summary>
        /// The amount of raw keys this inventory contains.
        /// </summary>
        [JsonPropertyName("keys")]
        public int Keys { get; init; }

        /// <summary>
        /// The currently used item slots for this inventory.
        /// </summary>
        [JsonIgnore]
        public int UsedSlots => _slots.Used;

        /// <summary>
        /// The total item slots for this inventory.
        /// </summary>
        [JsonIgnore]
        public int TotalSlots => _slots.Total;

        [JsonPropertyName("slots")]
        [JsonInclude]
        private Slots _slots = new Slots();

        [JsonPropertyName("updated")]
        [JsonInclude]
        private int _lastUpdate;
    }
}