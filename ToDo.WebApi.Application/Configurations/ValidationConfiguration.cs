﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Application.Configurations
{
    public class ValidationConfiguration : IInstaller
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
