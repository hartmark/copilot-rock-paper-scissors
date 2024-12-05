using System.Text.Json;
using System.Text.Json.Serialization;

namespace RockPaperScissors.Api;

public class EnumStringAndIntConverter<T> : JsonConverter<T> where T : Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var intValue = root.GetProperty("intValue").GetInt32();
        return (T)Enum.ToObject(typeof(T), intValue);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteNumber("intValue", (int)(object)value); // Write int value
        writer.WriteString("stringValue", value.ToString()); // Write string value
        writer.WriteEndObject();
    }
}