using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class AuthConfiguration : IMiddlewareInstaller
    {
        public void AddMiddlewareInstaller(WebApplication app)
        {
            app.UseAuthorization();
        }
    }
}
