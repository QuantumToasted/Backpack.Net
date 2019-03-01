using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents the response returned by the /users/info/v1 endpoint.
    /// </summary>
    public sealed class BackpackUsers
    {
        internal BackpackUsers()
        { }

        /// <summary>
        /// Whether or not the request was successful.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess => _response?.IsSuccess ?? true; // api does not return a response model on success

        /// <summary>
        /// If <see cref="IsSuccess"/> is false, this is error reason explaining why the request failed.
        /// </summary>
        [JsonIgnore]
        public string ErrorMessage => _response?.ErrorMessage; // api does not return a response model on success

        /// <summary>
        /// If <see cref="IsSuccess"/> is false, this may contain additional error information.
        /// </summary>
        [JsonIgnore]
        public string Reason => _response?.Reason; // api does not return a response model on success

        /// <summary>
        /// A collection of <see cref="BackpackUser"/>s.
        /// </summary>
        [JsonIgnore]
        public ImmutableArray<BackpackUser> Users => _users.Select(x => x.Value.WithId(ulong.Parse(x.Key))).ToImmutableArray();

        [JsonProperty("users")]
        private readonly Dictionary<string, BackpackUser> _users;

        [JsonProperty("response")]
        private readonly BackpackResponse _response;
    }
}