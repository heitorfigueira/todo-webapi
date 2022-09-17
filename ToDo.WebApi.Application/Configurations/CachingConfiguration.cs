using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using ToDo.WebApi.Application.Services;
using WebApi.Framework.DataAccess.Caching;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Application.Configurations
{
    public class CachingConfiguration : IInstaller
    {
        public int InstallerOrder = 1;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (environment == "Local" || environment == "Development")
                ConfigureMemoryCache(services);
            else
                ConfigureDistributedCache(services, configuration);
        }

        private IServiceCollection ConfigureMemoryCache(IServiceCollection services)
        {
            services.AddLazyCache();
            services.AddScoped<ICachingService, MemoryCacheService>();

            return services;
        }

        private IServiceCollection ConfigureDistributedCache(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedMemoryCache();
            services.AddScoped<ICachingService, DistributedCacheService>();

            services.AddSingleton<IConnectionMultiplexer>(provider => 
                ConnectionMultiplexer.Connect(
                    configuration.GetConnectionString("RedisConnection")));

            return services;
        }
    }
}
