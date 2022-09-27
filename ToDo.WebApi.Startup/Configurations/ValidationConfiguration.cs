﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class ValidationConfiguration : IInstaller
    {
        public int InstallerOrder = 99;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
