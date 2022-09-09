using Microsoft.AspNetCore.Diagnostics;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class ErrorHandlingConfiguration : IMiddlewareInstaller
    {
        public void AddMiddlewareInstaller(WebApplication app)
        {
            app.UseExceptionHandler("/error");
            app.Map("/error", (HttpContext httpContext) => Results.Problem());
        }
    }
}
