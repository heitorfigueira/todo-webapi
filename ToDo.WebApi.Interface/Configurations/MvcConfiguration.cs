using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class MvcConfiguration : IInstaller, IMiddlewareInstaller
    {
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
