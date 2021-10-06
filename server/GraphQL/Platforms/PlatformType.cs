using System.Linq;
using server.Data;
using server.Models;
using HotChocolate;
using HotChocolate.Types;

namespace server.GraphQL.Platforms
{
    public class PlatformResolver
    {
        public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDbContext context)
        {
            return context.Commands.Where<Command>(p => p.PlatformId == platform.Id);
        }
    }
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface.");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique ID for the platform.");

            descriptor
                .Field(p => p.Name)
                .Description("Represents the name for the platform.");

            descriptor
                .Field(p => p.LicenseKey).Ignore();

            descriptor
                .Field("commands")
                .ResolveWith<PlatformResolver>(p => p.GetCommands(default, default))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of available commands for this platform.");
        }

    }
}
