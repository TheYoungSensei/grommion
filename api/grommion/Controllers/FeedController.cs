using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedAPI.Controllers 
{
  [Route("api/[controller]")]
  [ApiController]
  public class FeedController : ControllerBase
  {
    private static List<Feed> feeds = new List<Feed>
      {
        new Feed { Id = 1, Title = "Test", Description = "Test", Author = "Christopher Sacré"}
      };

    [HttpGet]
    public async Task<ActionResult<List<Feed>>> Get()
    {
      return Ok(feeds);
    }

    [HttpPost]
    public async Task<ActionResult<Feed>> AddFeed(Feed feed)
    {
      feeds.Add(feed);
      return Ok(feed);
    }
  }
}