using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class MvcConfiguration : IInstaller, IMiddlewareInstaller
    {
        public int InstallerOrder = 4;
        public int MiddlewareOrder = 4;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
        }

        public void AddMiddlewareInstaller(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.MapControllers();
        }
    }
}
