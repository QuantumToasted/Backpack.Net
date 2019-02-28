using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="BackpackUser"/>'s voting and suggestion stats.
    /// </summary>
    public sealed class Voting
    {
        /// <summary>
        /// This user's site voting reputation.
        /// </summary>
        [JsonProperty("reputation")]
        public int Reputation { get; private set; }

        /// <summary>
        /// This user's total <see cref="Net.Votes"/>.
        /// </summary>
        [JsonProperty("votes")]
        public Votes Votes { get; private set; } = new Votes();

        /// <summary>
        /// This user's <see cref="PriceSuggestions"/> stats.
        /// </summary>
        [JsonProperty("suggestions")]
        public PriceSuggestions Suggestions { get; private set; } = new PriceSuggestions();
    }
}