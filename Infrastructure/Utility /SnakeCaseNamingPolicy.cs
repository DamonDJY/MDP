using System.Text.Json;

namespace MDP.Infrastructure.Utility;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
  public override string ConvertName(string name)
  {
    return string.Concat(name.Select((c, i) =>
        i > 0 && char.IsUpper(c) ? "_" + c : c.ToString())).ToLower();
  }
}

