using Newtonsoft.Json;

namespace Backpack.Net
{
    internal class BackpackResponse
    {
        [JsonProperty("message")]
        internal string ErrorMessage { get; private set; }

        [JsonProperty("success")]
        internal bool IsSuccess { get; private set; }

        [JsonProperty("reason")]
        internal string Reason { get; private set; }
    }
}