using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class SwaggerConfiguration : IInstaller, IMiddlewareInstaller
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen();
        }

        public void AddMiddlewareInstaller(WebApplication app)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
                RunDevelopmentSetup(app);
            else
                return;
        }

        private static void RunDevelopmentSetup(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
