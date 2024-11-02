using System.Text.Json;
using NetRedis.Models;
using StackExchange.Redis;

namespace NetRedis.Data
{
  public class RedisPlatformRepo : IPlatformRepo
  {
    private readonly IConnectionMultiplexer _redis;

    public RedisPlatformRepo(IConnectionMultiplexer redis)
    {
      _redis = redis;
    }

    public async Task CreatePlatform(Platform plat)
    {
      if (plat == null)
      {
        throw new ArgumentNullException(nameof(plat));
      }

      var db = _redis.GetDatabase();

      var serialPlat = JsonSerializer.Serialize(plat);

      await db.StringSetAsync(plat.Id, serialPlat);


    }

    public Task<IEnumerable<Platform>> GetAllPlatforms()
    {
      throw new NotImplementedException();
    }

    public async Task<Platform?> GetPlatformById(string id)
    {
      var db = _redis.GetDatabase();

      var platform = await db.StringGetAsync(id);

      if (!string.IsNullOrEmpty(platform))
      {
        return JsonSerializer.Deserialize<Platform>(platform!);
      }

      return null;
    }
  }
}