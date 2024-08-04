using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="BackpackUser"/>'s votes.
    /// </summary>
    public sealed class Votes
    {
        [JsonConstructor]
        internal Votes()
        { }

        /// <summary>
        /// The number of positive votes this user has cast.
        /// </summary>
        [JsonPropertyName("positive")]
        public int Positive { get; init; }

        /// <summary>
        /// The number of negative votes this user has cast.
        /// </summary>
        [JsonPropertyName("negative")]
        public int Negative { get; init; }

        /// <summary>
        /// The number of votes that were accepted or accurate.
        /// </summary>
        [JsonPropertyName("accepted")]
        public int Accepted { get; init; }
    }
}