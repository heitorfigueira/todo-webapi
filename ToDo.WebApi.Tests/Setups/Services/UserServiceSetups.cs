
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class UserServiceSetups
    {
        public static Mock<IUserService> MockGetValidEmailReturnsUser(User user)
        {
            var mock = new Mock<IUserService>();
            mock.Setup(service =>
                    service.Get(user.Email))
                    .Returns(user);

            return mock;
        }

        public static (UserService service, User user) GetValidEmailReturnsUser()
        {

            var user = UserFakers.GenerateSingleUser();

            return (GetValidEmailReturnsUser(user), user);
        }

        public static UserService GetValidEmailReturnsUser(User user)
        {
            var mockRepository = UserRepositorySetups.MockGetValidEmailReturnsUser(user);

            return new UserService(mockRepository.Object);
        }
    }
}
