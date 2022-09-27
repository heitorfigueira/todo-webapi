using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class AutoMapperConfiguration : IInstaller
    {
        public int InstallerOrder = 99;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
