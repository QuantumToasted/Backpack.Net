using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents an in-game item.
    /// </summary>
    public sealed class Item
    {
        internal Item()
        { }

        [JsonIgnore]
        private string _name;

        internal Item WithName(string name)
        {
            _name = name;
            return this;
        }

        /// <summary>
        /// The item definitions indexes that could represent this particular item.
        /// </summary>
        [JsonProperty("defindex")]
        public ImmutableArray<int> DefinitionIndexes { get; private set; }

        /// <summary>
        /// A mapping of valid qualities to <see cref="ItemPrice"/>s.
        /// </summary>
        [JsonIgnore]
        public ImmutableSortedDictionary<Quality, ItemPrice> Qualities
            => _prices.ToImmutableSortedDictionary(x => (Quality) int.Parse(x.Key),
                x => x.Value.WithName(_name).WithQuality((Quality) int.Parse(x.Key)));

        [JsonProperty("prices")]
        private Dictionary<string, ItemPrice> _prices;
    }
}