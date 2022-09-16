using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class CachingConfiguration //: IInstaller
    {
        public int InstallerOrder = 1;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local")
                services.AddMemoryCache(); // TODO: use lazycaching
            else
                services.AddDistributedMemoryCache(); // TODO: use redis
        }
    }
}
