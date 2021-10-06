using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using server.GraphQL.Platforms;
using server.GraphQL;
using GraphQL.Server.Ui.Voyager;
using server.GraphQL.Commands;

namespace server
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Share DB Context between resolvers
            services.AddPooledDbContextFactory<AppDbContext>(options =>
                                   options.UseNpgsql(Configuration.GetConnectionString("CommanderServerConnection")));

            services
                .AddGraphQLServer()
                .AddProjections()
                .AddQueryType<Query>()
                .AddType<PlatformType>()
                .AddType<CommandType>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            }, "/graphql-voyager");

        }
    }
}
