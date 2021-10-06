using HotChocolate;
using System.Linq;
using HotChocolate.Types;
using server.Data;
using server.Models;

namespace server.GraphQL.Commands
{

    public class CommandResolver
    {
        public Platform GetPlatform([Parent] Command command, [ScopedService] AppDbContext context)
        {
            return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
        }
    }
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("CLI Commands Available");

            descriptor
                .Field("platform")
                .ResolveWith<CommandResolver>(c => c.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Software or service CLI this command belongs too");
        }

    }
}
