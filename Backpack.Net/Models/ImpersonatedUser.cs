using System;
using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a frequently impersonated user on backpack.tf.
    /// </summary>
    public sealed class ImpersonatedUser
    {
        /// <summary>
        /// This user's SteamID64 identifier.
        /// </summary>
        [JsonIgnore]
        public ulong SteamId => ulong.Parse(_steamId);

        /// <summary>
        /// This user's Steam persona name.
        /// </summary>
        [JsonProperty("personaname")]
        public string Name { get; private set; }

        /// <summary>
        /// This user's Steam persona avatar.
        /// </summary>
        [JsonIgnore]
        public Uri AvatarUrl => new Uri(_avatar);

        [JsonProperty("avatar")]
        private readonly string _avatar;

        [JsonProperty("steamid")]
        private readonly string _steamId;
    }
}