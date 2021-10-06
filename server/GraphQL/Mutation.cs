using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using server.Data;
using server.GraphQL.Platforms;
using server.GraphQL.Commands;
using server.Models;
using HotChocolate.Subscriptions;
using System.Threading;

namespace server.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatform(
            AddPlatformInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var platform = new Platform
            {
                Name = input.Name
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommand(AddCommandInput input, [ScopedService] AppDbContext context)
        {
            var command = new Command
            {
                Line = input.Line,
                HowTo = input.HowTo,
                PlatformId = input.PlatformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync();
            return new AddCommandPayload(command);
        }
    }
}
