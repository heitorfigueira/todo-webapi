
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Domain.Enums;

namespace ToDo.WebApi.Tests.Unit.Mocks.Services
{
    public static class AccountServiceMocks
    {
        public static Mock<IAccountService> Mock()
        {
            return new Mock<IAccountService>();
        }

        #region Get
        public static Mock<IAccountService> SetupGetValidIdReturnsAccount(this Mock<IAccountService> mock, Account account)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<Guid>()))
                    .Returns(account);

            return mock;
        }
        public static Mock<IAccountService> SetupGetInvalidIdReturnsNull(this Mock<IAccountService> mock)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<Guid>()))
                    .Returns<Account>(null);

            return mock;
        }
        #endregion

        #region Create
        public static Mock<IAccountService> SetupCreateReturnsAccount(this Mock<IAccountService> mock, Account account)
        {
            mock.Setup(service =>
                    service.Create(It.IsAny<CreateAccount>()))
                    .Returns(account);

            return mock;
        }
        public static Mock<IAccountService> SetupCreateReturnsCreationFailedError(this Mock<IAccountService> mock)
        {
            mock.Setup(service =>
                    service.Create(It.IsAny<CreateAccount>()))
                    .Returns(Errors.Repository.CreationFailed);

            return mock;
        }
        #endregion

        #region Delete
        public static Mock<IAccountService> SetupDeleteReturnsAccount(this Mock<IAccountService> mock, Account account)
        {
            mock.Setup(service =>
                    service.Delete(It.IsAny<Guid>()))
                    .Returns(account);

            return mock;
        }
        public static Mock<IAccountService> SetupDeleteReturnsDeletionFailedError(this Mock<IAccountService> mock)
        {
            mock.Setup(service =>
                    service.Delete(It.IsAny<Guid>()))
                    .Returns(Errors.Repository.DeletionFailed);

            return mock;
        }
        #endregion

        #region Update
        public static Mock<IAccountService> SetupUpdateReturnsAccount(this Mock<IAccountService> mock, Account account)
        {
            mock.Setup(service =>
                    service.Update(It.IsAny<UpdateAccount>()))
                    .Returns(account);

            return mock;
        }
        public static Mock<IAccountService> SetupUpdateReturnsUpdateFailedError(this Mock<IAccountService> mock)
        {
            mock.Setup(service =>
                    service.Update(It.IsAny<UpdateAccount>()))
                    .Returns(Errors.Repository.CreationFailed);

            return mock;
        }
        #endregion
    }
}
