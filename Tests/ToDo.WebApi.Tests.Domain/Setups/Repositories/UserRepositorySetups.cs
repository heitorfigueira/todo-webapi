using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Entity;
using System.Linq.Expressions;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using ToDo.WebApi.Infrastructure.Repositories;
using WebApi.Framework.DataAccess.Caching;

namespace ToDo.WebApi.Tests.Domain.Setups.Repositories
{
    public static class UserRepositorySetups
    {
        public static (UserRepository repository, User user) SetupGetByEmailValidEmailReturnsUser()
        {
            var user = UserFakers.GenerateSingleUser();

            return (SetupGetByEmailValidEmailReturnsUser(user), user);

        }

        public static UserRepository SetupGetByEmailValidEmailReturnsUser(User user)
        {
            var _contextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UserGetByEmailValidEmailReturnsUser")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            using var context = new ApplicationContext(_contextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Add(user);
            context.SaveChanges();

            var mockCaching = new Mock<ICachingService>();

            return new UserRepository(context, mockCaching.Object);
        }

        public static UserRepository SetupGetByEmailInvalidEmailReturnsNull()
        {
            var _contextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UserGetByEmailInvalidEmailReturnsNull")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            using var context = new ApplicationContext(_contextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var mockCaching = new Mock<ICachingService>();

            return new UserRepository(context, mockCaching.Object);
        }
    }
}
