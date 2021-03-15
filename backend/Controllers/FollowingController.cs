using backend.Models;
using backend.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FollowingController : ControllerBase
  {
    private readonly FollowingService _fs;

    public FollowingController(FollowingService fs)
    {
      _fs = fs;
    }

    [HttpPost]
    [Authorize]
    public async System.Threading.Tasks.Task<ActionResult<string>> Create([FromBody] Following newFollowing)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        Following following = _fs.Create(newFollowing, userInfo);
        return Ok(following);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public async System.Threading.Tasks.Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _fs.delete(id, userInfo.Id);
        return Ok("success");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}