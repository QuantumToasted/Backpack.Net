using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    internal sealed class BooleanConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType switch
            {
                JsonTokenType.Number when reader.TryGetInt32(out var value) => value == 1,
                JsonTokenType.True => true,
                JsonTokenType.False => false,
                _ => throw new JsonException()
            };
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
            => writer.WriteBooleanValue(value);
    }
}