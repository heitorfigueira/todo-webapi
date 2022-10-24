using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Settings;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    internal class SettingsConfiguration //: IInstaller
    {
        public int InstallerOrder = 2;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthSettings>(configuration.GetSection(nameof(AuthSettings)))
                    .Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)))
                    .Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        }
    }
}
