using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Application.Configurations
{
    public class ValidationConfiguration : IInstaller
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddFluentValidation()
                .AddValidatorsFromAssembly(typeof(ValidationConfiguration).Assembly);
        }
    }
}
