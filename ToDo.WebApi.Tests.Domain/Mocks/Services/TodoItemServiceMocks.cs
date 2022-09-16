
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Domain.Mocks;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class TodoItemServiceMocks
    {
        public static Mock<ITodoItemService> Mock()
        {
            return new Mock<ITodoItemService>();
        }

        #region Get
        public static Mock<ITodoItemService> SetupGetValidIdReturnsTodoItem(this Mock<ITodoItemService> mock, int Id, TodoItem item)
        {
            mock.Setup(service =>
                    service.Get(Id))
                    .Returns(item);

            return mock;
        }
        public static Mock<ITodoItemService> SetupGetInvalidIdReturnsNull(this Mock<ITodoItemService> mock, int Id)
        {
            mock.Setup(service =>
                    service.Get(Id))
                    .Returns<TodoItem>(null);

            return mock;
        }
        #endregion

        #region Create
        public static Mock<ITodoItemService> SetupCreateReturnsTodoItem(this Mock<ITodoItemService>  mock, TodoItem item)
        {
            mock.Setup(service =>
                    service.Create(It.IsAny<CreateToDoItem>()))
                    .Returns(item);

            return mock;
        }
        public static Mock<ITodoItemService> SetupCreateReturnsCreationFailedError(this Mock<ITodoItemService> mock)
        {
            mock.Setup(service =>
                    service.Create(It.IsAny<CreateToDoItem>()))
                    .Returns(Errors.Repository.CreationFailed);

            return mock;
        }
        #endregion

        #region Delete
        public static Mock<ITodoItemService> SetupDeleteReturnsCreationFailedError(this Mock<ITodoItemService> mock)
        {
            mock.Setup(service =>
                    service.Delete(It.IsAny<int>()))
                    .Returns(Errors.Repository.DeletionFailed);

            return mock;
        }
        public static Mock<ITodoItemService> SetupDeleteReturnsTodoItem(this Mock<ITodoItemService> mock, TodoItem item)
        {
            mock.Setup(service =>
                    service.Delete(It.IsAny<int>()))
                    .Returns(item);

            return mock;
        }
        public static Mock<ITodoItemService> SetupDeleteReturnsDeletionFailedError(this Mock<ITodoItemService> mock, TodoItem item)
        {
            mock.Setup(service =>
                    service.Delete(item.Id))
                    .Returns(Errors.Repository.DeletionFailed);

            return mock;
        }
        #endregion

        #region Update
        public static Mock<ITodoItemService> SetupUpdateReturnsTodoItem(this Mock<ITodoItemService> mock, TodoItem item)
        {
            mock.Setup(service =>
                    service.Update(It.IsAny<UpdateToDoItem>()))
                    .Returns(item);

            return mock;
        }
        public static Mock<ITodoItemService> SetupUpdateReturnsUpdateFailedError(this Mock<ITodoItemService> mock)
        {
            mock.Setup(service =>
                    service.Update(It.IsAny<UpdateToDoItem>()))
                    .Returns(Errors.Repository.CreationFailed);

            return mock;
        }
        #endregion
    }
}
