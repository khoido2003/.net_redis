using NetRedis.Models;

namespace NetRedis.Data
{
  public interface IPlatformRepo
  {
    Task CreatePlatform(Platform plat);
    Task<Platform?> GetPlatformById(string id);
    Task<IEnumerable<Platform>> GetAllPlatforms();
  }
}