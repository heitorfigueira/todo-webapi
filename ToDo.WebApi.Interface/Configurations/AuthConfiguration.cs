using WebApi.Framework.Extensions;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class AuthConfiguration : IInstaller, IMiddlewareInstaller
    {
        public int Order = 1;
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddCredentialHasher(configuration, "PasswordSecret");
            //services.AddJwtProvider(configuration, "JwtConfiguration");
        }

        public void AddMiddlewareInstaller(WebApplication app)
        {
            app.UseAuthorization();
        }
    }
}
