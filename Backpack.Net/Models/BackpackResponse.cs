using System.Text.Json.Serialization;

namespace Backpack.Net
{
    internal class BackpackResponse
    {
        [JsonPropertyName("message")]
        [JsonInclude]
        internal string ErrorMessage { get; init; } = null!;

        [JsonPropertyName("success")]
        [JsonInclude]
        internal bool IsSuccess { get; init; }

        [JsonPropertyName("reason")]
        [JsonInclude]
        internal string Reason { get; init; } = null!;
    }
}