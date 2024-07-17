using ASPProjectBackend.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ASPProjectBackend.Data.Converters;

public class RequirementsConverter : JsonConverter<RequirementsWrapper>
{
    public override RequirementsWrapper? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.StartArray:
                JsonSerializer.Deserialize<List<object>>(ref reader, options);
                return new RequirementsWrapper() { IsEmptyArray = true };

            case JsonTokenType.StartObject:
                {
                    var requirements = JsonSerializer.Deserialize<RequirementsObject>(ref reader, options);
                    return new RequirementsWrapper { RequirementsObject = requirements };
                }

            default:
                throw new JsonException("Unexpected token type for requirements");
        }
    }

    public override void Write(Utf8JsonWriter writer, RequirementsWrapper value, JsonSerializerOptions options)
    {
        if (value.IsEmptyArray)
        {
            writer.WriteStartArray();
            writer.WriteEndArray();
        }
        else
        {
            JsonSerializer.Serialize(writer, value.RequirementsObject, options);
        }
    }
}
