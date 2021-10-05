using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<Platform> Platforms { get; set; }
        
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)           // A platform has many commands
                .WithOne(p => p.Platform)           // A command has one platform
                .HasForeignKey(p => p.PlatformId);  // on FK platformId

            modelBuilder
                .Entity<Command>()
                .HasOne(c => c.Platform)            // A command has one platform
                .WithMany(c => c.Commands)          // A platform has many commands
                .HasForeignKey(c => c.PlatformId);  // on FK platformId
        }
    }
}
