using ErrorOr;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Tests.Unit.Mocks.Repositories
{
    public static class AccountRepositoryMocks
    {
        public static Mock<IAccountRepository> Mock()
        {
            return new Mock<IAccountRepository>();
        }

        #region Get
        public static Mock<IAccountRepository> SetupGetValidIdReturnsAccount(this Mock<IAccountRepository> mock, Account account)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<Guid>()))
                    .Returns(account);

            return mock;
        }
        public static Mock<IAccountRepository> SetupGetInvalidIdReturnsNull(this Mock<IAccountRepository> mock)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<Guid>()))
                    .Returns<Account>(null);

            return mock;
        }
        #endregion

        #region Create
        public static Mock<IAccountRepository> SetupCreateReturnsAccount(this Mock<IAccountRepository> mock, Account account)
        {

            mock.Setup(service =>
                service.Create(It.IsAny<Account>()))
                .Returns(account);

            return mock;
        }
        public static Mock<IAccountRepository> SetupCreateReturnsNull(this Mock<IAccountRepository> mock)
        {

            mock.Setup(service =>
                service.Create(It.IsAny<Account>()))
                .Returns<Account>(null);

            return mock;
        }
        #endregion

        #region Delete
        public static Mock<IAccountRepository> SetupDeleteReturnsAccount(this Mock<IAccountRepository> mock, Account account)
        {

            mock.Setup(service =>
                service.Delete(account.Id))
                .Returns(account);

            return mock;
        }
        public static Mock<IAccountRepository> SetupDeleteReturnsNull(this Mock<IAccountRepository> mock)
        {

            mock.Setup(service =>
                service.Delete(It.IsAny<Account>()))
                .Returns<Account>(null);

            return mock;
        }
        #endregion

        #region Update
        public static Mock<IAccountRepository> SetupUpdateReturnsTrue(this Mock<IAccountRepository> mock, Account account)
        {

            mock.Setup(service =>
                service.Update(account))
                .Returns(true);

            return mock;
        }
        public static Mock<IAccountRepository> SetupUpdateReturnsFalse(this Mock<IAccountRepository> mock)
        {

            mock.Setup(service =>
                service.Update(It.IsAny<Account>()))
                .Returns(false);

            return mock;
        }
        #endregion
    }
}
