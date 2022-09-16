using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Settings;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Application.Configurations
{
    internal class SettingsConfiguration : IInstaller
    {
        public int InstallerOrder = 2;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthSettings>(configuration.GetSection(nameof(AuthSettings)))
                    .Configure<ConnectionStringSettings>(configuration.GetSection(nameof(ConnectionStringSettings)))
                    .Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        }
    }
}
