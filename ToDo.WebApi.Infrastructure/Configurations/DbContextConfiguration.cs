using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class DbContextConfiguration : IInstaller, IMiddlewareInstaller
    { 
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local")
                RunLocalEnvironmentServicesSetup(services, configuration);
            else
                RunDevelopentEnvironmentServiceSetup(services, configuration);
        }

        private void RunLocalEnvironmentServicesSetup(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "ApplicationLocalDb"));
        }

        private void RunDevelopentEnvironmentServiceSetup(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseNpgsql(configuration["ConnectionStrings:DefaultDatabaseConnection"]));
        }

        public void AddMiddlewareInstaller(WebApplication app)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Local")
                return;
        }
    }
}
