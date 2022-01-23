using Microsoft.EntityFrameworkCore;

namespace FeedAPI.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Feed> Feeds { get; set; }
  }
}