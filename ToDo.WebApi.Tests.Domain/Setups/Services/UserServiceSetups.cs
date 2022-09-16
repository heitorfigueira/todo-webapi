
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class UserServiceSetups
    {
        public static Mock<IUserService> Mock()
        {
            return new Mock<IUserService>();
        }

        #region Get
        public static Mock<IUserService> SetupGetValidEmailReturnsUser(this Mock<IUserService> mock, string Email, User user)
        {
            mock.Setup(service =>
                    service.Get(Email))
                    .Returns(user);

            return mock;
        }

        public static Mock<IUserService> SetupGetInvalidEmailReturnsNull(this Mock<IUserService> mock, string Email)
        {
            mock.Setup(service =>
                    service.Get(Email))
                    .Returns<User>(null);

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

        public static UserService GetInvalidEmailReturnsNull()
        {
            var mockRepository = UserRepositorySetups.MockGetInvalidEmailReturnsNull();

            return new UserService(mockRepository.Object);
        }
        #endregion

        #region Create
        public static Mock<IUserService> SetupCreateReturnsUser(this Mock<IUserService>  mock, User user)
        {
            mock.Setup(service =>
                    service.Create(It.IsAny<User>()))
                    .Returns(user);

            return mock;
        }

        public static Mock<IUserService> SetupCreateReturnsNull(this Mock<IUserService> mock, User user)
        {
            mock.Setup(service =>
                    service.Create(user))
                    .Returns<User>(null);

            return mock;
        }
        #endregion
    }
}
