using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="BackpackUser"/>'s price suggestion stats.
    /// </summary>
    public sealed class PriceSuggestions
    {
        [JsonConstructor]
        internal PriceSuggestions()
        { }

        /// <summary>
        /// The number of price suggestions this user has created.
        /// </summary>
        [JsonPropertyName("created")]
        public int Created { get; init; }

        /// <summary>
        /// The number of price suggestions this user has had accepted.
        /// </summary>
        [JsonPropertyName("accepted")]
        public int Accepted { get; init; }

        /// <summary>
        /// the number of price suggestions for unusual items this user has had accepted.
        /// </summary>
        [JsonPropertyName("accepted_unusual")]
        public int AcceptedUnusual { get; init; }
    }
}