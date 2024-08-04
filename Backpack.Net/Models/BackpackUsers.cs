using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents the response returned by the /users/info/v1 endpoint.
    /// </summary>
    public sealed class BackpackUsers
    {
        [JsonConstructor]
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
        public string? ErrorMessage => _response?.ErrorMessage; // api does not return a response model on success

        /// <summary>
        /// If <see cref="IsSuccess"/> is false, this may contain additional error information.
        /// </summary>
        [JsonIgnore]
        public string? Reason => _response?.Reason; // api does not return a response model on success

        /// <summary>
        /// A collection of <see cref="BackpackUser"/>s.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<BackpackUser> Users => _users.Where(x => x.Value.ValueKind != JsonValueKind.Array)
            .Select(x => x.Value.Deserialize<BackpackUser>(BackpackClient.JsonOptions)!.WithId(ulong.Parse(x.Key))).ToList();

        [JsonPropertyName("users")]
        [JsonInclude]
        private Dictionary<string, JsonElement> _users = null!;

        [JsonPropertyName("response")]
        [JsonInclude]
        private BackpackResponse? _response;
    }
}