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
        new Feed { Id = 1, Title = "Test", Description = "Test", Author = "Christopher Sacré"},
        new Feed { Id = 2, Title = "Test2", Description = "Test2", Author = "Christopher Sacré"}
      };

    [HttpGet]
    public async Task<ActionResult<List<Feed>>> Get()
    {
      return Ok(feeds);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Feed>> Get(int id)
    {
      var feed = feeds.Find(f => f.Id == id);
      if (feed == null)
        return NotFound("Feed not found");
      return feed;
    }

    [HttpPost]
    public async Task<ActionResult<Feed>> AddFeed(Feed feed)
    {
      feeds.Add(feed);
      return Ok(feed);
    }

    [HttpPut]
    public async Task<ActionResult<Feed>> UpdateFeed(Feed request)
    {
      var feed = feeds.Find(f => f.Id == request.Id);
      if (feed == null)
        return NotFound("Feed not found");
      feed.Title = request.Title;
      feed.Description = request.Description;
      feed.Author = request.Author;

      return Ok(feed);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Feed>> DeleteFeed(int id)
    {
      var feed = feeds.Find(f => f.Id == id);
      if (feed == null)
        return NotFound("Feed not found");
      feeds.Remove(feed);
      return Ok(feed);
    }
  }
}