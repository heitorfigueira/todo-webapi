using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Framework.ErrorHandling;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class ErrorHandlingConfiguration : IInstaller, IMiddlewareInstaller
    {
        public int InstallerOrder = 5;
        public int MiddlewareOrder = 5;
        public void AddMiddlewareInstaller(WebApplication app)
        {
            app.UseExceptionHandler("/error");
            app.Map("/error", (HttpContext httpContext) => Results.Problem());
        }

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ProblemDetailsFactory, ErrorInformationProblemDetailsFactory>();
        }
    }
}
