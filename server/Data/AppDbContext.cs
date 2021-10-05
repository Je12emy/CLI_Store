using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<Platform> Platforms { get; set; }
    }
}
