using System.Linq;
using HotChocolate;
using server.Data;
using server.Models;

namespace server.GraqlQL
{
    public class Query
    {
        // The DB context can be inject through the method call thanks to the Chocolate Framework, very similar to Apollo Server.
        public IQueryable<Platform> GetPlatform([Service] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}
