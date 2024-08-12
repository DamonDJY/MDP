namespace MDP.Infrastructure.Utility;

using System.Text.Encodings.Web;
using System.Text.Json;

/// <summary>
/// Json帮助类
/// </summary>
public class JsonHelper
{
  // 写入默认格式
  public static readonly JsonSerializerOptions s_writeOptions = new()
  {
    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower, // 驼峰命名
    Converters = { new FmDateTimeConverter() },// 自定义日期时间转换器
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // 禁止uni编码
  };

  public static string Serialize<T>(T value)
  {
    return JsonSerializer.Serialize(value, s_writeOptions);
  }

  public static T? Deserialize<T>(string json)
  {
    return JsonSerializer.Deserialize<T>(json, s_writeOptions);
  }
}

