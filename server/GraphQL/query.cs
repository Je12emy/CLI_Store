using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using server.Data;
using server.Models;

namespace server.GraqlQL
{
    public class Query
    {
        // Make use of the DB Context from the Pool
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            // The DB context can be injected through the method call thanks to the Chocolate Framework, very similar to Apollo Server.
            return context.Platforms;
        }
    }
}
