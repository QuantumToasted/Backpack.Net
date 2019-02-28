using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="BackpackUser"/>'s votes.
    /// </summary>
    public sealed class Votes
    {
        /// <summary>
        /// The number of positive votes this user has cast.
        /// </summary>
        [JsonProperty("positive")]
        public int Positive { get; private set; }

        /// <summary>
        /// The number of negative votes this user has cast.
        /// </summary>
        [JsonProperty("negative")]
        public int Negative { get; private set; }

        /// <summary>
        /// The number of votes that were accepted or accurate.
        /// </summary>
        [JsonProperty("accepted")]
        public int Accepted { get; private set; }
    }
}