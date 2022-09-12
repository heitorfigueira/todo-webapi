using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Settings;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class DbContextConfiguration : IInstaller, IMiddlewareInstaller
    {
        public int Order = 2;
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local")
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "ApplicationLocalDb"));
            else
                services.AddDbContext<ApplicationContext>(options =>
                     options.UseNpgsql(configuration.GetConnectionString("DefaultDatabaseConnection")));
        }

        public void AddMiddlewareInstaller(WebApplication app)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Local")
                return;
        }
    }
}
