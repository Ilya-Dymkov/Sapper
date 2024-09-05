using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sapper.Models.Source;

public class JsonSymbolConverter : JsonConverter<CellSymbol>
{
    public override CellSymbol Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        (CellSymbol)reader.GetString()![0];

    public override void Write(Utf8JsonWriter writer, CellSymbol value, JsonSerializerOptions options) => 
        writer.WriteStringValue(((char)value).ToString());
}