using System;
using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="BackpackUser"/>'s inventory.
    /// </summary>
    public sealed class Inventory
    {
        /// <summary>
        /// This inventory's ranking on backpack.tf.
        /// </summary>
        [JsonProperty("ranking")]
        public int Ranking { get; private set; }

        /// <summary>
        /// This inventory's value, in the lowest currency.
        /// </summary>
        [JsonProperty("value")]
        public decimal Value { get; private set; }

        /// <summary>
        /// The last time this inventory was updated.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset LastUpdated => BackpackClient.UnixEpoch.AddSeconds(_lastUpdate);

        /// <summary>
        /// The amount of raw metal (refined) this inventory contains.
        /// </summary>
        [JsonProperty("metal")]
        public decimal Metal { get; private set; }

        /// <summary>
        /// The amount of raw keys this inventory contains.
        /// </summary>
        [JsonProperty("keys")]
        public int Keys { get; private set; }

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

        [JsonProperty("slots")]
        private Slots _slots = new Slots();

        [JsonProperty("updated")]
        private readonly int _lastUpdate;
    }
}