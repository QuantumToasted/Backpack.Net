using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="BackpackUser"/>'s trust stats.
    /// </summary>
    public sealed class Trust
    {
        [JsonConstructor]
        internal Trust()
        { }

        /// <summary>
        /// The amount of positive trust votes this user has received.
        /// </summary>
        [JsonPropertyName("positive")]
        public int Positive { get; init; }

        /// <summary>
        /// The amount of negative trust votes this user has received.
        /// </summary>
        [JsonPropertyName("negative")]
        public int Negative { get; init; }
    }
}