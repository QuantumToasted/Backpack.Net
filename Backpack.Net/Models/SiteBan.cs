using System;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents an individual site ban on backpack.tf.
    /// </summary>
    public sealed class SiteBan
    {
        [JsonConstructor]
        internal SiteBan()
        { }

        /// <summary>
        /// The type of ban this is. See <seealso cref="SiteBanType"/> for a list of ban types.
        /// </summary>
        [JsonIgnore]
        public SiteBanType Type { get; private set; }

        internal SiteBan WithType(SiteBanType type)
        {
            Type = type;
            return this;
        }

        /// <summary>
        /// If set, the <see cref="DateTimeOffset"/> this ban expires. If not set, this ban is permanent.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? Expires
        {
            get
            {
                if (_end < 0)
                    return null;
                return BackpackClient.UnixEpoch.AddSeconds(_end);
            }
        }

        /// <summary>
        /// If set, the reason for this ban.
        /// </summary>
        [JsonPropertyName("reason")]
        public string? Reason { get; init; }

        [JsonPropertyName("end")]
        [JsonInclude]
        private int _end;
    }
}