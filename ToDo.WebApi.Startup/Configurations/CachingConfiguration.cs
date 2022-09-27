using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using ToDo.WebApi.Application.Services;
using WebApi.Framework.Caching;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class CachingConfiguration : IInstaller
    {
        public int InstallerOrder = 1;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (environment == "Development" || environment == "Local")
                ConfigureMemoryCache(services);
            else
                ConfigureDistributedCache(services, configuration);
        }

        public IServiceCollection ConfigureMemoryCache(IServiceCollection services)
        {
            services.AddLazyCache();
            services.AddTransient<ICachingService, MemoryCacheService>();

            return services;
        }

        private IServiceCollection ConfigureDistributedCache(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedMemoryCache();
            services.AddTransient<ICachingService, DistributedCacheService>();

            services.AddSingleton<IConnectionMultiplexer>(provider => 
                ConnectionMultiplexer.Connect(
                    configuration.GetConnectionString("RedisConnection")));

            return services;
        }
    }
}
