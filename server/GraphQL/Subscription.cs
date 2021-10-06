using HotChocolate;
using HotChocolate.Types;
using server.Models;

namespace server.GraphQL
{
    public class Subscription 
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded ([EventMessage] Platform platform) => platform;
        
    }
}