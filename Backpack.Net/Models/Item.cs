using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents an in-game item.
    /// </summary>
    public sealed class Item
    {
        [JsonConstructor]
        internal Item()
        { }

        [JsonIgnore]
        private string _name = null!;

        internal Item WithName(string name)
        {
            _name = name;
            return this;
        }

        /// <summary>
        /// The item definitions indexes that could represent this particular item.
        /// </summary>
        [JsonPropertyName("defindex")]
        public IReadOnlyList<int> DefinitionIndexes { get; init; } = null!;

        /// <summary>
        /// A mapping of valid qualities to <see cref="ItemPrice"/>s.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyDictionary<Quality, ItemPrice> Qualities
            => _prices.ToDictionary(x => (Quality)int.Parse(x.Key), x => x.Value.WithName(_name).WithQuality((Quality)int.Parse(x.Key)));

        [JsonPropertyName("prices")]
        [JsonInclude]
        private Dictionary<string, ItemPrice> _prices = null!;
    }
}