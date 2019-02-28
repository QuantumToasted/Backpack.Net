using System.Collections.Immutable;
using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents the response returned by the /IGetUsers/GetImpersonatedUsers endpoint.
    /// </summary>
    public sealed class ImpersonatedUsers
    {
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
        /// A collection of <see cref="ImpersonatedUser"/>s.
        /// </summary>
        [JsonProperty("results")]
        public ImmutableArray<ImpersonatedUser> Users { get; private set; }

        /// <summary>
        /// The total number of impersonated users on backpack.tf. Used for pagination.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; private set; }

        [JsonProperty("response")]
        private readonly BackpackResponse _response;
    }
}