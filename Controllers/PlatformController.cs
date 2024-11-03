using Microsoft.AspNetCore.Mvc;
using NetRedis.Data;
using NetRedis.Models;

namespace NetRedis.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class PlatformController : ControllerBase
  {
    private readonly IPlatformRepo _repo;

    public PlatformController(IPlatformRepo repo)
    {
      _repo = repo;
    }

    [HttpGet("{id}", Name = "GetPlatformById")]
    public async Task<ActionResult<Platform>> GetPlatformById(String id)
    {
      var platform = await _repo.GetPlatformById(id);

      if (platform != null)
      {
        return Ok(platform);
      }
      return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Platform>> CreatePlatform(Platform platform)
    {
      await _repo.CreatePlatform(platform);

      return CreatedAtRoute(nameof(GetPlatformById), new Platform { Id = platform.Id }, platform);
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Platform>>> GetAllPlatforms()
    {
      return Ok(await _repo.GetAllPlatforms());
    }
  }
}