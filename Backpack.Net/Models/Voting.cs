using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="BackpackUser"/>'s voting and suggestion stats.
    /// </summary>
    public sealed class Voting
    {
        [JsonConstructor]
        internal Voting()
        { }

        /// <summary>
        /// This user's site voting reputation.
        /// </summary>
        [JsonPropertyName("reputation")]
        public int Reputation { get; init; }

        /// <summary>
        /// This user's total <see cref="Net.Votes"/>.
        /// </summary>
        [JsonPropertyName("votes")]
        public Votes Votes { get; init; } = new Votes();

        /// <summary>
        /// This user's <see cref="PriceSuggestions"/> stats.
        /// </summary>
        [JsonPropertyName("suggestions")]
        public PriceSuggestions Suggestions { get; init; } = new PriceSuggestions();
    }
}