
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Mocks;
using ToDo.WebApi.Tests.Unit.Mocks.Repositories;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class TodoItemServiceSetups
    {

        #region Get
        public static (TodoItemService service, TodoItem item) GetValidIdReturnsTodoItem()
        {

            var item = TodoItemFakers.GenerateSingleItem(3);

            return (GetValidIdReturnsTodoItem(item), item);
        }
        public static TodoItemService GetValidIdReturnsTodoItem(TodoItem item)
        {
            var mockRepository = TodoItemRepositoryMocks.Mock().SetupGetValidIdReturnsTodoItem(item);

            return new TodoItemService(MapperMocks.Mock().Object, mockRepository.Object);
        }
        public static TodoItemService GetInvalidIdReturnsNull()
        {
            var mockRepository = TodoItemRepositoryMocks.Mock().SetupGetInvalidIdReturnsNull();

            return new TodoItemService(MapperMocks.Mock().Object, mockRepository.Object);
        }
        #endregion

        #region Create
        public static TodoItemService CreateReturnsTodoItem(TodoItem item)
        {
            var mockTodoItemRepository = TodoItemRepositoryMocks.Mock()
                                        .SetupCreateReturnsTodoItem(item);

            return new TodoItemService(MapperMocks.Mock().Object, mockTodoItemRepository.Object);
        }
        public static (TodoItemService service, TodoItem item) CreateReturnsTodoItem()
        {
            var item = TodoItemFakers.GenerateSingleItem(3);

            return (CreateReturnsTodoItem(item), item);
        }
        public static TodoItemService CreateReturnsCreationFailedError()
        {
            var mockTodoItemRepository = TodoItemRepositoryMocks.Mock()
                                        .SetupCreateReturnsNull();

            return new TodoItemService(MapperMocks.Mock().Object, mockTodoItemRepository.Object);
        }
        #endregion

        #region Delete
        public static TodoItemService DeleteReturnsDeletionFailedError()
        {

            var mockTodoItemRepository = TodoItemRepositoryMocks.Mock()
                                        .SetupGetValidIdReturnsTodoItem(new())
                                        .SetupDeleteReturnsNull();

            return new TodoItemService(MapperMocks.Mock().Object, mockTodoItemRepository.Object);
        }
        public static TodoItemService DeleteReturnsTodoItem(TodoItem item)
        {
            var mockTodoItemRepository = TodoItemRepositoryMocks.Mock()
                                        .SetupGetValidIdReturnsTodoItem(item)
                                        .SetupDeleteReturnsTodoItem(item);

            return new TodoItemService(MapperMocks.Mock().Object, mockTodoItemRepository.Object);
        }
        public static (TodoItemService service, TodoItem item) DeleteReturnsTodoItem()
        {
            var item = TodoItemFakers.GenerateSingleItem(3);

            return (DeleteReturnsTodoItem(item), item);
        }
        #endregion

        #region Update
        public static TodoItemService UpdateReturnsTodoItem(TodoItem item)
        {
            var mockTodoItemRepository = TodoItemRepositoryMocks.Mock()
                                        .SetupGetValidIdReturnsTodoItem(item)
                                        .SetupUpdateReturnsTrue(item);

            return new TodoItemService(MapperMocks.Mock().Object, mockTodoItemRepository.Object);
        }
        public static (TodoItemService service, TodoItem item) UpdateReturnsTodoItem()
        {
            var item = TodoItemFakers.GenerateSingleItem(3);

            return (UpdateReturnsTodoItem(item), item);
        }
        public static TodoItemService UpdateReturnsUpdateFailedError(TodoItem item)
        {
            var mockTodoItemRepository = TodoItemRepositoryMocks.Mock()
                                            .SetupGetValidIdReturnsTodoItem(item)
                                            .SetupUpdateReturnsFalse();

            return new TodoItemService(MapperMocks.Mock().Object, mockTodoItemRepository.Object);
        }
        public static (TodoItemService service, TodoItem item) UpdateReturnsUpdateFailedError()
        {
            var item = TodoItemFakers.GenerateSingleItem(3);

            return (UpdateReturnsUpdateFailedError(item), item);
        }
        public static TodoItemService UpdateReturnsNotFoundError(TodoItem item)
        {
            var mockTodoItemRepository = TodoItemRepositoryMocks.Mock()
                                        .SetupGetInvalidIdReturnsNull();

            return new TodoItemService(MapperMocks.Mock().Object, mockTodoItemRepository.Object);
        }
        public static (TodoItemService service, TodoItem item) UpdateReturnsNotFoundError()
        {
            var item = TodoItemFakers.GenerateSingleItem(3);

            return (UpdateReturnsNotFoundError(item), item);
        }
        #endregion
    }
}
