using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace multihub_server
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseSignalR(builder =>
            {
                builder.MapHub<MultiHub>(HubContract.Uri.AbsolutePath);
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Hello1Hub>();
            services.AddScoped<Hello2Hub>();
            services.AddSignalR(options =>
            {

            });
            services.AddLogging(z =>
            {
                z.AddConsole().SetMinimumLevel(LogLevel.Trace);
            });

        }
    }

}
