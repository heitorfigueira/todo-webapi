using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApi.Framework.ErrorHandling;
using WebApi.Framework.Extensions;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
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
