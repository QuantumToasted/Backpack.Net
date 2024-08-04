using System;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a frequently impersonated user on backpack.tf.
    /// </summary>
    public sealed class ImpersonatedUser
    {
        [JsonConstructor]
        internal ImpersonatedUser()
        { }

        /// <summary>
        /// This user's SteamID64 identifier.
        /// </summary>
        [JsonIgnore]
        public ulong SteamId => ulong.Parse(_steamId);

        /// <summary>
        /// This user's Steam persona name.
        /// </summary>
        [JsonPropertyName("personaname")]
        public string Name { get; init; } = null!;

        /// <summary>
        /// This user's Steam persona avatar.
        /// </summary>
        [JsonIgnore]
        public Uri AvatarUrl => new Uri(_avatar);

        [JsonPropertyName("avatar")]
        [JsonInclude]
        private string _avatar = null!;

        [JsonPropertyName("steamid")]
        [JsonInclude]
        private string _steamId = null!;
    }
}