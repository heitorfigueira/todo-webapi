using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class HealthCheckConfiguration : IInstaller, IMiddlewareInstaller
    {

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
