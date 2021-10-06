using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using server.Data;
using server.GraphQL.Platforms;
using server.Models;

namespace server.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatform (AddPlatformInput input, [ScopedService] AppDbContext context) 
        {
            var platform = new Platform {
              Name = input.Name        
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync();
            return new AddPlatformPayload(platform);
        }
    }
}
