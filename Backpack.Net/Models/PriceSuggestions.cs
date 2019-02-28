using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="BackpackUser"/>'s price suggestion stats.
    /// </summary>
    public sealed class PriceSuggestions
    {
        /// <summary>
        /// The number of price suggestions this user has created.
        /// </summary>
        [JsonProperty("created")]
        public int Created { get; private set; }

        /// <summary>
        /// The number of price suggestions this user has had accepted.
        /// </summary>
        [JsonProperty("accepted")]
        public int Accepted { get; private set; }

        /// <summary>
        /// the number of price suggestions for unusual items this user has had accepted.
        /// </summary>
        [JsonProperty("accepted_unusual")]
        public int AcceptedUnusual { get; private set; }
    }
}