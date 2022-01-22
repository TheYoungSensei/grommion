using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedAPI.Controllers 
{
  [Route("api/[controller]")]
  [ApiController]
  public class FeedController : ControllerBase
  {
    [HttpGet]
    public async Task<ActionResult<List<Feed>>> Get()
    {
      var feeds = new List<Feed>
      {
        new Feed { Id = 1, Title = "Test", Description = "Test", Author = "Christopher Sacré"}
      };
      return Ok(feeds);
    }
  }
}