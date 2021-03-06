using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using server.Data;
using server.Models;

namespace server.GraphQL
{
    public class Query
    {
        // Make use of the DB Context from the Pool
        //[UseProjection] // Generate Joins if needed, I wish we had this in TypeORM
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            // The DB context can be injected through the method call thanks to the Chocolate Framework, very similar to Apollo Server.
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}
