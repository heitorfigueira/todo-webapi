using ErrorOr;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Tests.Unit.Mocks.Repositories
{
    public static class TodoListRepositoryMocks
    {
        public static Mock<ITodoListRepository> Mock()
        {
            return new Mock<ITodoListRepository>();
        }

        #region Get
        public static Mock<ITodoListRepository> SetupGetValidIdReturnsTodoList(this Mock<ITodoListRepository> mock, TodoList list)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<int>()))
                    .Returns(list);

            return mock;
        }
        public static Mock<ITodoListRepository> SetupGetInvalidIdReturnsNull(this Mock<ITodoListRepository> mock)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<int>()))
                    .Returns<TodoList>(null);

            return mock;
        }
        #endregion

        #region Create
        public static Mock<ITodoListRepository> SetupCreateReturnsTodoList(this Mock<ITodoListRepository> mock, TodoList list)
        {

            mock.Setup(service =>
                service.Create(It.IsAny<TodoList>()))
                .Returns(list);

            return mock;
        }
        public static Mock<ITodoListRepository> SetupCreateReturnsNull(this Mock<ITodoListRepository> mock)
        {

            mock.Setup(service =>
                service.Create(It.IsAny<TodoList>()))
                .Returns<TodoList>(null);

            return mock;
        }
        #endregion

        #region Delete
        public static Mock<ITodoListRepository> SetupDeleteReturnsTodoList(this Mock<ITodoListRepository> mock, TodoList list)
        {

            mock.Setup(service =>
                service.Delete(list.Id))
                .Returns(list);

            return mock;
        }
        public static Mock<ITodoListRepository> SetupDeleteReturnsNull(this Mock<ITodoListRepository> mock)
        {

            mock.Setup(service =>
                service.Delete(It.IsAny<TodoList>()))
                .Returns<TodoList>(null);

            return mock;
        }
        #endregion

        #region Update
        public static Mock<ITodoListRepository> SetupUpdateReturnsTrue(this Mock<ITodoListRepository> mock)
        {

            mock.Setup(service =>
                service.Update(It.IsAny<TodoList>()))
                .Returns(true);

            return mock;
        }
        public static Mock<ITodoListRepository> SetupUpdateReturnsFalse(this Mock<ITodoListRepository> mock)
        {

            mock.Setup(service =>
                service.Update(It.IsAny<TodoList>()))
                .Returns(false);

            return mock;
        }
        #endregion
    }
}
