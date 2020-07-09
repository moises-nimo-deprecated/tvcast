using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TvCast.Domain;
using TvCast.Entity;

namespace TvCast.ApiWorker
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDataLayer(hostContext.Configuration);
                    services.AddDomainLayer(hostContext.Configuration);
                    services.AddHostedService<TvMazeShowScrapperWorker>();
                });
    }
}