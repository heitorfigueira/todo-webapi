using ErrorOr;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Tests.Unit.Mocks.Repositories
{
    public static class TodoItemRepositoryMocks
    {
        public static Mock<ITodoItemRepository> Mock()
        {
            return new Mock<ITodoItemRepository>();
        }

        #region Get
        public static Mock<ITodoItemRepository> SetupGetValidIdReturnsTodoItem(this Mock<ITodoItemRepository> mock, TodoItem item)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<int>()))
                    .Returns(item);

            return mock;
        }
        public static Mock<ITodoItemRepository> SetupGetInvalidIdReturnsNull(this Mock<ITodoItemRepository> mock)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<int>()))
                    .Returns<TodoItem>(null);

            return mock;
        }
        #endregion

        #region Create
        public static Mock<ITodoItemRepository> SetupCreateReturnsTodoItem(this Mock<ITodoItemRepository> mock, TodoItem item)
        {

            mock.Setup(service =>
                service.Create(It.IsAny<TodoItem>()))
                .Returns(item);

            return mock;
        }
        public static Mock<ITodoItemRepository> SetupCreateReturnsNull(this Mock<ITodoItemRepository> mock)
        {

            mock.Setup(service =>
                service.Create(It.IsAny<TodoItem>()))
                .Returns<TodoItem>(null);

            return mock;
        }
        #endregion

        #region Delete
        public static Mock<ITodoItemRepository> SetupDeleteReturnsTodoItem(this Mock<ITodoItemRepository> mock, TodoItem item)
        {

            mock.Setup(service =>
                service.Delete(item.Id))
                .Returns(item);

            return mock;
        }
        public static Mock<ITodoItemRepository> SetupDeleteReturnsNull(this Mock<ITodoItemRepository> mock)
        {

            mock.Setup(service =>
                service.Delete(It.IsAny<TodoItem>()))
                .Returns<TodoItem>(null);

            return mock;
        }
        #endregion

        #region Update
        public static Mock<ITodoItemRepository> SetupUpdateReturnsTrue(this Mock<ITodoItemRepository> mock, TodoItem item)
        {

            mock.Setup(service =>
                service.Update(item))
                .Returns(true);

            return mock;
        }
        public static Mock<ITodoItemRepository> SetupUpdateReturnsFalse(this Mock<ITodoItemRepository> mock)
        {

            mock.Setup(service =>
                service.Update(It.IsAny<TodoItem>()))
                .Returns(false);

            return mock;
        }
        #endregion
    }
}
