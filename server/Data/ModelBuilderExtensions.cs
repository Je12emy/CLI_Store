using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public static class ModelBuilderExtensions 
    {
        public static void Seed (this ModelBuilder modelBuilder) 
        {


            // Seed: https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
            modelBuilder.Entity<Platform>().HasData(new Platform
            {
                Id = 1,
                Name = ".Net",
                LicenseKey = ""
            });

            modelBuilder.Entity<Platform>().HasData(new Platform
            {
                Id = 2,
                Name = "Docker",
                LicenseKey = ""
            });

            modelBuilder.Entity<Command>().HasData(
                    new Command
                    {
                        Id = 1,
                        HowTo = "build a project",
                        Line = "dotnet build",
                        PlatformId = 1
                    },
                    new Command
                    {
                        Id = 2,
                        HowTo = "run a project",
                        Line = "dotnet run",
                        PlatformId = 1
                    },

                    new Command
                    {
                        Id = 3,
                        HowTo = "add a nuget package",
                        Line = "dotnet add package <package name>",
                        PlatformId = 1
                    });


            modelBuilder.Entity<Command>().HasData(
                    new Command
                    {
                        Id = 4,
                        HowTo = "view running containers",
                        Line = "docker container ls",
                        PlatformId = 2
                    },
                    new Command
                    {
                        Id = 5,
                        HowTo = "view available images",
                        Line = "docker image ls",
                        PlatformId = 2
                    });

        }
    }
}
