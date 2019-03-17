using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace multihub_server
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(
            string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(o =>
            {
                o.Listen(System.Net.IPAddress.Parse(HubContract.Uri.Host), HubContract.Uri.Port);

            }).UseStartup<Startup>();
    }

}
