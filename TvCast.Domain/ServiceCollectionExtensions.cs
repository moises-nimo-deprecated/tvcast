using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TvCast.Domain.AutomapperProfiles;
using TvCast.Domain.Services;
using TvCast.Domain.Services.Impl;

namespace TvCast.Domain
{
    /// <summary>
    /// Static Extensions to be called by the .Net Core service Initialization.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the Domain Layer related services to the <see cref="IServiceCollection"/>
        /// for Dependency Injection
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/> parameter used to build .Net Core Apps</param>
        /// <param name="configuration"><see cref="IConfiguration"/> retrieved from appsettings.json in .Net Core App Context</param>
        /// <returns></returns>
        public static IServiceCollection AddDomainLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CastProfile());
                mc.AddProfile(new ShowProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IShowsService, ShowsService>();
            services.AddTransient<ITvMazeSavingService, TvMazeSavingService>();
            return services;
        }
    }
}