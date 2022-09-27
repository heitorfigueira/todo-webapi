using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDo.WebApi.Startup.Configurations;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Caching;
using WebApi.Framework.Extensions;

namespace Todo.WebApi.Tests.Integration
{
    public class TodoApiFactory : WebApplicationFactory<SerilogConfiguration>, IAsyncLifetime
    {
        private readonly PostgreSqlTestcontainer _dbContainer =
            new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(new PostgreSqlTestcontainerConfiguration()
            {
                Database = "testedb",
                Username = "admin",
                Password = "secretpassword!234",
            })
            .WithImage("postgres:latest")
            .WithWaitStrategy(
                Wait.ForUnixContainer()
                .UntilPortIsAvailable(5432))
            .WithCleanUp(true)
            .Build();


        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var defaultCaching = services.SingleOrDefault(d => d.ServiceType == typeof(ICachingService));
                if (defaultCaching != null) services.Remove(defaultCaching);

                var infraCachingConfig = new CachingConfiguration();
                infraCachingConfig.ConfigureMemoryCache(services);

                services.RemoveDbContext<ApplicationContext>();

                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseNpgsql(_dbContainer.ConnectionString);
                }, ServiceLifetime.Transient, ServiceLifetime.Transient);

                services.EnsureDbCreated<ApplicationContext>();
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
        }

        async Task IAsyncLifetime.DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }
    }
}
