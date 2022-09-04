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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

        }
    }
}
