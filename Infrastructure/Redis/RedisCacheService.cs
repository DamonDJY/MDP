using StackExchange.Redis;

namespace MDP.Infrastructure.Redis;

public class RedisCacheService
{
  private readonly IConnectionMultiplexer _redis;

  public RedisCacheService(IConnectionMultiplexer redis)
  {
    _redis = redis;
  }

  public async Task<string> GetValueAsync(string key)
  {
    var db = _redis.GetDatabase();
    return await db.StringGetAsync(key);
  }

  public async Task SetValueAsync(string key, string value)
  {
    var db = _redis.GetDatabase();
    await db.StringSetAsync(key, value);
  }
}
