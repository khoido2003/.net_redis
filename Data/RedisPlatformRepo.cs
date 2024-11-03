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

      // OLD implementation that use Strings and Sets in Redis

      // await db.StringSetAsync(plat.Id, serialPlat);
      // await db.SetAddAsync("PlatformSet", serialPlat);

      // Using Hashes
      await db.HashSetAsync("hashplatform", [new HashEntry(plat.Id, serialPlat)]);

    }

    public async Task<IEnumerable<Platform?>?> GetAllPlatforms()
    {
      var db = _redis.GetDatabase();

      // Using Strings and Sets in Redid

      // var completeSet = await db.SetMembersAsync("PlatformSet");

      var completeSet = await db.HashGetAllAsync("hashplatform");

      if (completeSet.Length > 0)
      {
        var obj = Array.ConvertAll(completeSet, (val) => JsonSerializer.Deserialize<Platform>(val.Value!)).ToList();

        Console.WriteLine(JsonSerializer.Serialize(obj));

        return obj;
      }
      return null;
    }

    public async Task<Platform?> GetPlatformById(string id)
    {
      var db = _redis.GetDatabase();

      // var platform = await db.StringGetAsync(id);

      var platform = await db.HashGetAsync("hashplatform", id);

      if (!string.IsNullOrEmpty(platform))
      {
        return JsonSerializer.Deserialize<Platform>(platform!);
      }
      return null;
    }


  }
}