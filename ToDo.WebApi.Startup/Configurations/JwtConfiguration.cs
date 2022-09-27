using ToDo.WebApi.Startup.Middlewares;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class JwtConfiguration : IMiddlewareInstaller
    {
        public int MiddlewareOrder = 6;
        public void AddMiddlewareInstaller(WebApplication app)
        {
            app.UseMiddleware<JwtMiddleware>();
        }
    }
}
