using System.Collections.Generic;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _prs;
    private readonly PostsService _ps;

    private readonly FollowingService _fs;

    public ProfilesController(ProfilesService prs, PostsService ps, FollowingService fs)
    {
      _prs = prs;
      _ps = ps;
      _fs = fs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Profile>> GetAll()
    {
      try
      {
        return Ok(_prs.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        Profile profile = _prs.GetProfileById(id);
        return Ok(profile);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/posts")]
    public ActionResult<IEnumerable<Post>> GetPosts(string id)
    {
      try
      {
        return Ok(_ps.GetByProfile(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/following")]
    public ActionResult<List<IEnumerable<Post>>> GetFollowing(string id)
    {
      try
      {
        return Ok(_fs.GetByProfile(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}