
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;

namespace ToDo.WebApi.Tests.Unit.Mocks.Services
{
    public static class TodoListServiceMocks
    {
        public static Mock<ITodoListService> Mock()
        {
            return new Mock<ITodoListService>();
        }

        #region Get
        public static Mock<ITodoListService> SetupGetValidIdReturnsTodoList(this Mock<ITodoListService> mock, TodoList list)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<int>()))
                    .Returns(list);

            return mock;
        }
        public static Mock<ITodoListService> SetupGetInvalidIdReturnsNull(this Mock<ITodoListService> mock)
        {
            mock.Setup(service =>
                    service.Get(It.IsAny<int>()))
                    .Returns<TodoList>(null);

            return mock;
        }
        #endregion

        #region Create
        public static Mock<ITodoListService> SetupCreateReturnsTodoList(this Mock<ITodoListService> mock, TodoList list)
        {
            mock.Setup(service =>
                    service.Create(It.IsAny<CreateTodoList>()))
                    .Returns(list);

            return mock;
        }
        public static Mock<ITodoListService> SetupCreateReturnsCreationFailedError(this Mock<ITodoListService> mock)
        {
            mock.Setup(service =>
                    service.Create(It.IsAny<CreateTodoList>()))
                    .Returns(Errors.Repository.CreationFailed);

            return mock;
        }
        #endregion

        #region Delete
        public static Mock<ITodoListService> SetupDeleteReturnsCreationFailedError(this Mock<ITodoListService> mock)
        {
            mock.Setup(service =>
                    service.Delete(It.IsAny<int>()))
                    .Returns(Errors.Repository.DeletionFailed);

            return mock;
        }
        public static Mock<ITodoListService> SetupDeleteReturnsTodoList(this Mock<ITodoListService> mock, TodoList list)
        {
            mock.Setup(service =>
                    service.Delete(It.IsAny<int>()))
                    .Returns(list);

            return mock;
        }
        public static Mock<ITodoListService> SetupDeleteReturnsDeletionFailedError(this Mock<ITodoListService> mock)
        {
            mock.Setup(service =>
                    service.Delete(It.IsAny<int>()))
                    .Returns(Errors.Repository.DeletionFailed);

            return mock;
        }
        #endregion

        #region Update
        public static Mock<ITodoListService> SetupUpdateReturnsTodoList(this Mock<ITodoListService> mock, TodoList list)
        {
            mock.Setup(service =>
                    service.Update(It.IsAny<UpdateTodoList>()))
                    .Returns(list);

            return mock;
        }
        public static Mock<ITodoListService> SetupUpdateReturnsUpdateFailedError(this Mock<ITodoListService> mock)
        {
            mock.Setup(service =>
                    service.Update(It.IsAny<UpdateTodoList>()))
                    .Returns(Errors.Repository.CreationFailed);

            return mock;
        }
        #endregion
    }
}
