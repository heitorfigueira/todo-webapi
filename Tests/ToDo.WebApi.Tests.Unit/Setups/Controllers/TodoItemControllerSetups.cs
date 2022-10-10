using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Enums;
using ToDo.WebApi.Interface.Controllers;
using ToDo.WebApi.Tests.Unit.Mocks;
using ToDo.WebApi.Tests.Unit.Mocks.Services;
using ToDo.WebApi.Tests.Unit.Setups.Services;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Unit.Setups.Controllers
{
    public static class TodoItemControllerSetups
    {
        #region Create
        public static (TodoItemController controller, TodoItem item) CreateOnSuccessReturnsTodoItem(int todoListId)
        {
            var item = TodoItemFakers.GenerateSingleItem(todoListId);

            return (CreateOnSuccessReturnsTodoItem(item), item);
        }

        public static TodoItemController CreateOnSuccessReturnsTodoItem(TodoItem item)
        {
            var mockListService = TodoItemServiceMocks.Mock().SetupCreateReturnsTodoItem(item);

            return new(mockListService.Object);
        }

        public static TodoItemController CreateOnFailureReturnsCreationFailedError()
        {
            var mockListService = TodoItemServiceMocks.Mock().SetupCreateReturnsCreationFailedError();

            return new(mockListService.Object);
        }
        #endregion
        #region Delete
        public static TodoItemController DeleteOnSuccessReturnsTodoItem(TodoItem item)
        {

            var mockTodoItemService = TodoItemServiceMocks.Mock().SetupDeleteReturnsTodoItem(item);

            return new(mockTodoItemService.Object);
        }

        public static (TodoItemController controller, TodoItem item) DeleteOnSuccessReturnsTodoItem()
        {
            var item = TodoItemFakers.GenerateSingleItem(3);

            return (DeleteOnSuccessReturnsTodoItem(item), item);
        }

        public static TodoItemController DeleteOnFailureReturnsDeletionFailedError()
        {
            var mockTodoItemService = TodoItemServiceMocks.Mock().SetupDeleteReturnsDeletionFailedError();

            return new(mockTodoItemService.Object);
        }
        #endregion

        #region Update
        public static TodoItemController UpdateOnSuccessReturnsTodoItem(TodoItem item)
        {

            var mockTodoItemService = TodoItemServiceMocks.Mock().SetupUpdateReturnsTodoItem(item);

            return new(mockTodoItemService.Object);
        }

        public static (TodoItemController controller, TodoItem item) UpdateOnSuccessReturnsTodoItem()
        {
            var item = TodoItemFakers.GenerateSingleItem(3);

            return (UpdateOnSuccessReturnsTodoItem(item), item);
        }

        public static TodoItemController UpdateOnFailureReturnsUpdateFailedError()
        {
            var mockTodoItemService = TodoItemServiceMocks.Mock().SetupUpdateReturnsUpdateFailedError();

            return new(mockTodoItemService.Object);
        }
        #endregion

        #region Get
        public static TodoItemController GetOnSuccessReturnsTodoItem(TodoItem item)
        {

            var mockTodoItemService = TodoItemServiceMocks.Mock().SetupGetValidIdReturnsTodoItem(item);

            return new(mockTodoItemService.Object);
        }

        public static (TodoItemController controller, TodoItem item) GetOnSuccessReturnsTodoItem()
        {
            var item = TodoItemFakers.GenerateSingleItem(3);

            return (GetOnSuccessReturnsTodoItem(item), item);
        }

        public static TodoItemController GetOnFailureReturnsNull()
        {
            var mockTodoItemService = TodoItemServiceMocks.Mock().SetupGetInvalidIdReturnsNull();

            return new(mockTodoItemService.Object);
        }
        #endregion
    }
}
