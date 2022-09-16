using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class UserRepositorySetups
    {
        public static Mock<IUserRepository> MockGetValidEmailReturnsUser(User user)
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(service =>
                    service.GetByEmail(user.Email))
                    .Returns(user);

            return mock;
        }
        public static Mock<IUserRepository> MockGetInvalidEmailReturnsNull()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(service =>
                    service.GetByEmail(It.IsAny<string>()))
                    .Returns<User>(null);

            return mock;
        }
    }
}
