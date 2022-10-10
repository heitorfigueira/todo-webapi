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
    public static class TodoListControllerSetups
    {
        #region Create
        public static (TodoListController controller, TodoList list) CreateOnSuccessReturnsTodoList()
        {
            var list = TodoListFakers.GenerateSingleList();

            return (CreateOnSuccessReturnsTodoList(list), list);
        }

        public static TodoListController CreateOnSuccessReturnsTodoList(TodoList list)
        {
            var mockListService = TodoListServiceMocks.Mock().SetupCreateReturnsTodoList(list);

            return new(mockListService.Object);
        }

        public static TodoListController CreateOnFailureReturnsCreationFailedError()
        {
            var mockListService = TodoListServiceMocks.Mock().SetupCreateReturnsCreationFailedError();

            return new(mockListService.Object);
        }
        #endregion

        #region Delete
        public static TodoListController DeleteOnSuccessReturnsTodoList(TodoList list)
        {

            var mockTodoListService = TodoListServiceMocks.Mock().SetupDeleteReturnsTodoList(list);

            return new(mockTodoListService.Object);
        }

        public static (TodoListController controller, TodoList list) DeleteOnSuccessReturnsTodoList()
        {
            var list = TodoListFakers.GenerateSingleList();

            return (DeleteOnSuccessReturnsTodoList(list), list);
        }

        public static TodoListController DeleteOnFailureReturnsDeletionFailedError()
        {
            var mockTodoListService = TodoListServiceMocks.Mock().SetupDeleteReturnsDeletionFailedError();

            return new(mockTodoListService.Object);
        }
        #endregion

        #region Update
        public static TodoListController UpdateOnSuccessReturnsTodoList(TodoList list)
        {

            var mockTodoListService = TodoListServiceMocks.Mock().SetupUpdateReturnsTodoList(list);

            return new(mockTodoListService.Object);
        }

        public static (TodoListController controller, TodoList list) UpdateOnSuccessReturnsTodoList()
        {
            var list = TodoListFakers.GenerateSingleList();

            return (UpdateOnSuccessReturnsTodoList(list), list);
        }

        public static TodoListController UpdateOnFailureReturnsUpdateFailedError()
        {
            var mockTodoListService = TodoListServiceMocks.Mock().SetupUpdateReturnsUpdateFailedError();

            return new(mockTodoListService.Object);
        }
        #endregion

        #region Get
        public static TodoListController GetOnSuccessReturnsTodoList(TodoList list)
        {

            var mockTodoListService = TodoListServiceMocks.Mock().SetupGetValidIdReturnsTodoList(list);

            return new(mockTodoListService.Object);
        }

        public static (TodoListController controller, TodoList list) GetOnSuccessReturnsTodoList()
        {
            var list = TodoListFakers.GenerateSingleList();

            return (GetOnSuccessReturnsTodoList(list), list);
        }

        public static TodoListController GetOnFailureReturnsNull()
        {
            var mockTodoListService = TodoListServiceMocks.Mock().SetupGetInvalidIdReturnsNull();

            return new(mockTodoListService.Object);
        }
        #endregion
    }
}
