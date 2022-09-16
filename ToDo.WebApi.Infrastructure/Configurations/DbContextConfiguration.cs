using Bogus;
using Bogus.DataSets;
using FakeItEasy;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Application.Settings;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
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
                     options.UseNpgsql(configuration.GetConnectionString("DefaultDatabaseConnection")));
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

            User adminUser = new()
            {
                Id = Guid.NewGuid(),
                Email = "admin@admin.adm",
                Password = hashService.HashPassword("Admin!234"),
                Account = new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Seed Admin User",
                    Type = Domain.Enums.AccountTypes.Administrator,
                    Created = DateTime.Now,
                    CreatedBy = ""
                },
                Created = DateTime.Now,
                CreatedBy = ""
            };

            applicationContext.Users.Add(adminUser);
            applicationContext.Accounts.Add(adminUser.Account);

            var seedUsers = new Faker<User>()
                            .CustomInstantiator(faker => new()
                            {
                                Id = faker.Random.Guid(),
                                Email = faker.Person.Email,
                                Password = hashService
                                                .HashPassword(faker.Internet.Password()),
                                Created = DateTime.Now,
                                CreatedBy = ""
                            })
                            .Generate(Int32.Parse(
                                app.Configuration["Randomizer:DefaultQuantityGeneration"]));

            var accountSeeder = new Faker<Account>()
                            .CustomInstantiator(faker => new()
                            {
                                Id = faker.Random.Guid(),
                                Name = faker.Person.FullName,
                                Type = Domain.Enums.AccountTypes.Common,
                                Created = DateTime.Now,
                                CreatedBy = ""
                            });


            var todoItemSeeder = new Faker<TodoItem>()
                           .CustomInstantiator(faker => new()
                           {
                               Description = faker.Lorem.Paragraph(1),
                               Done = faker.Random.Number() % 2 == 0 ? true : false
                           });

            var todoListsSeeder = new Faker<TodoList>()
                            .CustomInstantiator(faker => new()
                            {
                                Name = faker.Lorem.Lines(1),
                                Description = faker.Lorem.Lines(2)
                            });

            seedUsers.ForEach(user =>
            {
                applicationContext.Users.Add(user);
                applicationContext.Accounts.Add(
                    accountSeeder.RuleFor(account => account.UserId, user.Id).Generate());

                var lists = todoListsSeeder.GenerateBetween(0, 4);
                lists.ForEach(list =>
                {
                    list.Items = todoItemSeeder.RuleFor(item => item.TodoListId, list.Id)
                                               .GenerateBetween(1, 10);

                    applicationContext.TodoLists.Add(list);
                    applicationContext.TodoItems.AddRange(list.Items);
                    applicationContext.AccountTodoList.Add(new()
                    {
                        TodoListId = list.Id,
                        AccountId = user.Account!.Id
                    });
                });

            });

            applicationContext.SaveChanges();
        }
    }
}
