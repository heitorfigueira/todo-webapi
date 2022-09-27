using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class MvcConfiguration : IInstaller, IMiddlewareInstaller
    {
        public int InstallerOrder = 4;
        public int MiddlewareOrder = 2;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
        }

        public void AddMiddlewareInstaller(WebApplication app)
        {
            app.UseCors(opt => opt
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.MapControllers()
                .RequireAuthorization() ;
        }
    }
}
