using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class HealthCheckConfiguration : IInstaller, IMiddlewareInstaller
    {
        public int InstallerOrder = 99;
        public int MiddlewareOrder = 99;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();
        }
        public void AddMiddlewareInstaller(WebApplication app)
        {
            app.UseHealthChecks("/health");
        }
    }
}
