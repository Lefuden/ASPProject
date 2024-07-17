using System.Text.Json;
using System.Text.Json.Serialization;

namespace ASPProjectBackend.Data.Converters;

public class RequiredAgeConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
                return reader.GetInt32().ToString();

            case JsonTokenType.String:
                return reader.GetString();

            default:
                throw new JsonException("Unexpected token type for required_age");
        }
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        if (int.TryParse(value, out int intValue))
        {
            writer.WriteNumberValue(intValue);
        }
        else
        {
            writer.WriteStringValue(value);
        }
    }
}
