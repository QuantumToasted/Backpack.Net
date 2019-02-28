using System;
using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents an individual site ban on backpack.tf.
    /// </summary>
    public sealed class SiteBan
    {
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
        [JsonProperty("reason")]
        public string Reason { get; private set; }

        [JsonProperty("end")]
        private readonly int _end;
    }
}