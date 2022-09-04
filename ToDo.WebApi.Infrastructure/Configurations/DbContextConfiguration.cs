using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class DbContextConfiguration : IInstaller
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>();
        }
    }
}
