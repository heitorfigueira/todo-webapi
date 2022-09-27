
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;

namespace ToDo.WebApi.Tests.Unit.Mocks.Services
{
    public static class UserServiceMocks
    {
        public static Mock<IUserService> Mock()
        {
            return new Mock<IUserService>();
        }

        #region Get
        public static Mock<IUserService> SetupGetValidEmailReturnsUser(this Mock<IUserService> mock, User user)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<string>()))
                    .Returns(user);

            return mock;
        }

        public static Mock<IUserService> SetupGetReturnsNull(this Mock<IUserService> mock)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<string>()))
                    .Returns<User>(null);

            return mock;
        }
        #endregion

        #region Create
        public static Mock<IUserService> SetupCreateReturnsUser(this Mock<IUserService> mock, User user)
        {
            mock.Setup(service =>
                    service.Create(It.IsAny<User>()))
                    .Returns(user);

            return mock;
        }

        public static Mock<IUserService> SetupCreateReturnsCreationFailedError(this Mock<IUserService> mock)
        {
            mock.Setup(service =>
                    service.Create(It.IsAny<User>()))
                    .Returns(Errors.Repository.CreationFailed);

            return mock;
        }
        #endregion

        #region Delete
        public static Mock<IUserService> SetupDeleteReturnsCreationFailedError(this Mock<IUserService> mock)
        {
            mock.Setup(service =>
                    service.Delete(It.IsAny<Guid>()))
                    .Returns(Errors.Repository.DeletionFailed);

            return mock;
        }
        public static Mock<IUserService> SetupDeleteReturnsUser(this Mock<IUserService> mock, User user)
        {
            mock.Setup(service =>
                    service.Delete(It.IsAny<Guid>()))
                    .Returns(user);

            return mock;
        }

        public static Mock<IUserService> SetupDeleteReturnsDeletionFailedError(this Mock<IUserService> mock)
        {
            mock.Setup(service =>
                    service.Delete(It.IsAny<Guid>()))
                    .Returns(Errors.Repository.DeletionFailed);

            return mock;
        }
        #endregion
    }
}
