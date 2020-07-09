using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TvCast.Entity.Repositories;
using TvCast.Entity.Repositories.Impl;

namespace TvCast.Entity
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IShowsRepository, ShowsRepository>();
            services.AddTransient<ICastRepository, CastRepository>();
            services.AddTransient<TvCastDbContext>();
            return services;
        }
    }
}