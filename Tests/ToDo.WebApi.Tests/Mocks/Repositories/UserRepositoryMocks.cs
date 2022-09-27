using ErrorOr;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Tests.Unit.Mocks.Repositories
{
    public static class UserRepositoryMocks
    {
        public static Mock<IUserRepository> Mock()
        {
            return new Mock<IUserRepository>();
        }

        #region Get
        public static Mock<IUserRepository> SetupGetValidIdReturnsUser(this Mock<IUserRepository> mock, User user)
        {
            mock.Setup(service =>
                    service.Get(user.Id))
                    .Returns(user);

            return mock;
        }
        public static Mock<IUserRepository> SetupGetInvalidIdReturnsNull(this Mock<IUserRepository> mock)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<Guid>()))
                    .Returns<User>(null);

            return mock;
        }
        public static Mock<IUserRepository> SetupGetValidEmailReturnsUser(this Mock<IUserRepository> mock, User user)
        {
            mock.Setup(service =>
                    service.GetByEmail(user.Email))
                    .Returns(user);

            return mock;
        }
        public static Mock<IUserRepository> SetupGetInvalidEmailReturnsNull(this Mock<IUserRepository> mock)
        {
            mock.Setup(service =>
                    service.GetByEmail(It.IsAny<string>()))
                    .Returns<User>(null);

            return mock;
        }
        #endregion

        #region Create
        public static Mock<IUserRepository> SetupCreateReturnsUser(this Mock<IUserRepository> mock, User user)
        {

            mock.Setup(service =>
                service.Create(It.IsAny<User>()))
                .Returns(user);

            return mock;
        }
        public static Mock<IUserRepository> SetupCreateReturnsNull(this Mock<IUserRepository> mock)
        {

            mock.Setup(service =>
                service.Create(It.IsAny<User>()))
                .Returns<User>(null);

            return mock;
        }
        #endregion

        #region Delete
        public static Mock<IUserRepository> SetupDeleteReturnsUser(this Mock<IUserRepository> mock, User user)
        {

            mock.Setup(service =>
                service.Delete(user.Id))
                .Returns(user);

            return mock;
        }
        public static Mock<IUserRepository> SetupDeleteReturnsNull(this Mock<IUserRepository> mock)
        {

            mock.Setup(service =>
                service.Delete(It.IsAny<User>()))
                .Returns<User>(null);

            return mock;
        }
        #endregion
    }
}
