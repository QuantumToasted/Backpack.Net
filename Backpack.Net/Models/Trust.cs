using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="BackpackUser"/>'s trust stats.
    /// </summary>
    public sealed class Trust
    {
        /// <summary>
        /// The amount of positive trust votes this user has received.
        /// </summary>
        [JsonProperty("positive")]
        public int Positive { get; private set; }

        /// <summary>
        /// The amount of negative trust votes this user has received.
        /// </summary>
        [JsonProperty("negative")]
        public int Negative { get; private set; }
    }
}