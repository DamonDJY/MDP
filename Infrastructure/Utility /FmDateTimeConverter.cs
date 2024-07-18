namespace MDP.Infrastructure.Utility;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class FmDateTimeConverter : JsonConverter<DateTime>
{
  public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      if (DateTime.TryParseExact(reader.GetString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
      {
        return date;
      }
      if (DateTime.TryParse(reader.GetString(), out DateTime dateTime))
      {
        return dateTime;
      }
    }

    throw new JsonException($"Unable to parse datetime from: {reader.GetString()}");
  }

  public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
  {
    writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss")); // 自定义日期时间格式
  }

}
