using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class CachingConfiguration : IInstaller
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local")
                services.AddMemoryCache(); // TODO: use lazycaching
            else
                services.AddDistributedMemoryCache(); // TODO: use redis
        }
    }
}
