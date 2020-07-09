using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(TvCast.AzureFunctions.Startup))]
namespace TvCast.AzureFunctions
{
    
    public class Startup :  FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            
        }
    }
}