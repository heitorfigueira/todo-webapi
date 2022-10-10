using ErrorOr;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Entities.Relations;

namespace ToDo.WebApi.Tests.Unit.Mocks.Repositories
{
    public static class AccountTodoListRepositoryMocks
    {
        public static Mock<IAccountTodoListRepository> Mock()
        {
            return new Mock<IAccountTodoListRepository>();
        }

        #region Get
        public static Mock<IAccountTodoListRepository> SetupGetValidIdReturnsAccountTodoList(this Mock<IAccountTodoListRepository> mock, AccountTodoList account)
        {
            mock.Setup(service =>
                    service.Get(account.Id))
                    .Returns(account);

            return mock;
        }
        public static Mock<IAccountTodoListRepository> SetupGetInvalidIdReturnsNull(this Mock<IAccountTodoListRepository> mock)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<int>()))
                    .Returns<AccountTodoList>(null);

            return mock;
        }
        #endregion

        #region Create
        public static Mock<IAccountTodoListRepository> SetupCreateReturnsAccountTodoList(this Mock<IAccountTodoListRepository> mock, AccountTodoList account)
        {

            mock.Setup(service =>
                service.Create(It.IsAny<AccountTodoList>()))
                .Returns(account);

            return mock;
        }
        public static Mock<IAccountTodoListRepository> SetupCreateReturnsNull(this Mock<IAccountTodoListRepository> mock)
        {

            mock.Setup(service =>
                service.Create(It.IsAny<AccountTodoList>()))
                .Returns<AccountTodoList>(null);

            return mock;
        }
        #endregion

        #region Delete
        public static Mock<IAccountTodoListRepository> SetupDeleteReturnsAccountTodoList(this Mock<IAccountTodoListRepository> mock, AccountTodoList account)
        {

            mock.Setup(service =>
                service.Delete(account.Id))
                .Returns(account);

            return mock;
        }
        public static Mock<IAccountTodoListRepository> SetupDeleteReturnsNull(this Mock<IAccountTodoListRepository> mock)
        {

            mock.Setup(service =>
                service.Delete(It.IsAny<AccountTodoList>()))
                .Returns<AccountTodoList>(null);

            return mock;
        }
        #endregion

        #region Update
        public static Mock<IAccountTodoListRepository> SetupUpdateReturnsTrue(this Mock<IAccountTodoListRepository> mock, AccountTodoList account)
        {

            mock.Setup(service =>
                service.Update(account))
                .Returns(true);

            return mock;
        }
        public static Mock<IAccountTodoListRepository> SetupUpdateReturnsFalse(this Mock<IAccountTodoListRepository> mock)
        {

            mock.Setup(service =>
                service.Update(It.IsAny<AccountTodoList>()))
                .Returns(false);

            return mock;
        }
        #endregion
    }
}
