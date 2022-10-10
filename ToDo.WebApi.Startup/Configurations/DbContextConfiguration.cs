using Bogus;
using Bogus.DataSets;
using FakeItEasy;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;
using System.Data.Entity.Core.Metadata.Edm;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Settings;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Enums;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class DbContextConfiguration : IInstaller, IMiddlewareInstaller
    {
        public int InstallerOrder = 3;
        public int MiddlewareOrder = 99;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local")
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "ApplicationLocalDb"));
            else
                services.AddDbContext<ApplicationContext>(options =>
                     options.UseNpgsql(configuration.GetConnectionString("DefaultDatabaseConnection"), options =>
                     {
                     }), ServiceLifetime.Transient, ServiceLifetime.Transient);
        }

        public void AddMiddlewareInstaller(WebApplication app)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local")
                SeedLocalDatabase(app);
        }

        public void SeedLocalDatabase(WebApplication app)
        {
            Randomizer.Seed = new Random(Int32.Parse(app.Configuration["Randomizer:RandomizerSeed"]));

            var applicationContext = app.Services.GetRequiredService<ApplicationContext>();
            var hashService = app.Services.GetRequiredService<IHashService>();

            var adminId = Guid.NewGuid();

            User adminUser = new()
            {
                Id = adminId,
                Email = "admin@admin.adm",
                Password = hashService.HashPassword(adminId, "SuperAdmin!234")
            };

            applicationContext.Users.Add(adminUser);

            applicationContext.SaveChanges();

            var user = applicationContext.Users.FirstOrDefault(user => user.Email == adminUser.Email);

            var adminAccount = new Account()
            {
                Name = "Seed Admin User",
                TypeId = AccountTypes.Administrator,
                Created = DateTime.UtcNow,
                CreatedBy = user.Id
            };

            applicationContext.Accounts.Add(adminAccount);

            var seedUsers = UserFakers.InternalFaker()
                                .RuleFor(user => user.Password, 
                                        (faker, user) => hashService.HashPassword(user.Id, faker.Internet.Password()))
                                .Generate(Int32.Parse(app.Configuration["Randomizer:DefaultQuantityGeneration"]));

            seedUsers.ForEach(user =>
            {
                applicationContext.Users.Add(user);

                var account = AccountFakers.GenerateAccountTypeToUser(user.Id, AccountTypes.Common);

                applicationContext.Accounts.Add(account);

                var lists = TodoListFakers.InternalFaker().GenerateBetween(0, 4);

                lists.ForEach(list =>
                {
                    list.Items = TodoItemFakers.InternalFaker()
                                               .RuleFor(item => item.TodoListId, list.Id)
                                               .GenerateBetween(1, 10);

                    applicationContext.TodoLists.Add(list);
                    applicationContext.TodoItems.AddRange(list.Items);
                    applicationContext.AccountTodoList.Add(new()
                    {
                        TodoListId = list.Id,
                        AccountId = account.Id
                    });
                });
            });

            applicationContext.SaveChanges();
        }
    }
}
