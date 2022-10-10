
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Mocks;
using ToDo.WebApi.Tests.Unit.Mocks.Repositories;
using ToDo.WebApi.Tests.Unit.Mocks.Services;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class TodoListServiceSetups
    {

        #region Get
        public static (TodoListService service, TodoList list) GetValidIdReturnsTodoList()
        {

            var list = TodoListFakers.GenerateSingleList();

            return (GetValidIdReturnsTodoList(list), list);
        }
        public static TodoListService GetValidIdReturnsTodoList(TodoList list)
        {
            var mockRepository = TodoListRepositoryMocks.Mock().SetupGetValidIdReturnsTodoList(list);

            return new TodoListService(
                TodoItemServiceMocks.Mock().Object, mockRepository.Object,
                AccountTodoListRepositoryMocks.Mock().Object,
                MapperMocks.Mock().SetupMapAnyReturns<CreateTodoList, TodoList>(list).Object);
        }
        public static TodoListService GetInvalidIdReturnsNull()
        {
            var mockRepository = TodoListRepositoryMocks.Mock().SetupGetInvalidIdReturnsNull();

            return new TodoListService(
                TodoItemServiceMocks.Mock().Object,
                mockRepository.Object,
                AccountTodoListRepositoryMocks.Mock().Object,
                MapperMocks.Mock().Object);
        }
        #endregion

        #region Create
        public static TodoListService CreateReturnsTodoList(TodoList list)
        {
            var mockMapper = MapperMocks.Mock().SetupMapAnyReturns<CreateTodoList, TodoList>(new());
            var mockTodoListRepository = TodoListRepositoryMocks.Mock()
                                        .SetupCreateReturnsTodoList(list);

            var mockItemService = TodoItemServiceMocks.Mock().SetupCreateReturnsTodoItem(new());

            var mockAccountTodoListRepository = AccountTodoListRepositoryMocks.Mock().SetupCreateReturnsAccountTodoList(new());

            return new TodoListService(
                mockItemService.Object,
                mockTodoListRepository.Object,
                mockAccountTodoListRepository.Object,
                mockMapper.Object);
        }
        public static (TodoListService service, TodoList list) CreateReturnsTodoList()
        {
            var user = TodoListFakers.GenerateSingleList();

            return (CreateReturnsTodoList(user), user);
        }
        public static TodoListService CreateReturnsCreationFailedError()
        {
            var mockMapper = MapperMocks.Mock().SetupMapAnyReturns<CreateTodoList, TodoList>(new());
            var mockTodoListRepository = TodoListRepositoryMocks.Mock().SetupCreateReturnsNull();


            return new TodoListService(
                TodoItemServiceMocks.Mock().Object,
                mockTodoListRepository.Object,
                AccountTodoListRepositoryMocks.Mock().Object,
                mockMapper.Object);
        }
        #endregion

        #region Delete
        public static TodoListService DeleteReturnsDeletionFailedError()
        {

            var mockTodoListRepository = TodoListRepositoryMocks.Mock()
                                        .SetupGetValidIdReturnsTodoList(new())
                                        .SetupDeleteReturnsNull();

            return new TodoListService(
                TodoItemServiceMocks.Mock().Object,
                mockTodoListRepository.Object,
                AccountTodoListRepositoryMocks.Mock().Object,
                MapperMocks.Mock().Object);
        }
        public static TodoListService DeleteReturnsTodoList(TodoList list)
        {
            var mockTodoListRepository = TodoListRepositoryMocks.Mock()
                                        .SetupGetValidIdReturnsTodoList(list)
                                        .SetupDeleteReturnsTodoList(list);

            return new TodoListService(
                TodoItemServiceMocks.Mock().Object,
                mockTodoListRepository.Object,
                AccountTodoListRepositoryMocks.Mock().Object,
                MapperMocks.Mock().Object);
        }
        public static (TodoListService service, TodoList list) DeleteReturnsTodoList()
        {
            var user = TodoListFakers.GenerateSingleList();

            return (DeleteReturnsTodoList(user), user);
        }
        #endregion

        #region Update
        public static TodoListService UpdateReturnsTodoList(TodoList list)
        {
            var mockTodoListRepository = TodoListRepositoryMocks.Mock()
                                        .SetupGetValidIdReturnsTodoList(list)
                                        .SetupUpdateReturnsTrue();

            return new TodoListService(
                TodoItemServiceMocks.Mock().Object,
                mockTodoListRepository.Object,
                AccountTodoListRepositoryMocks.Mock().Object,
                MapperMocks.Mock().Object);
        }
        public static (TodoListService service, TodoList list) UpdateReturnsTodoList()
        {
            var user = TodoListFakers.GenerateSingleList();

            return (UpdateReturnsTodoList(user), user);
        }
        public static TodoListService UpdateReturnsUpdateFailedError()
        {
            var mockTodoListRepository = TodoListRepositoryMocks.Mock()
                                        .SetupGetValidIdReturnsTodoList(new())
                                        .SetupUpdateReturnsFalse();

            return new TodoListService(
                TodoItemServiceMocks.Mock().Object,
                mockTodoListRepository.Object,
                AccountTodoListRepositoryMocks.Mock().Object,
                MapperMocks.Mock().Object);
        }
        #endregion
    }
}
