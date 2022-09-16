using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
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
