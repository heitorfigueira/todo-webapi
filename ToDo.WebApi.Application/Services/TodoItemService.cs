using AutoMapper;
using ErrorOr;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using WebApi.Framework.DependencyInjection;

namespace ToDo.WebApi.Application.Services
{
    public class TodoItemService : TransientService, ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(
            IMapper mapper, 
            ITodoItemRepository todoItemRepository) : 
            base(mapper)
        {
            _todoItemRepository = todoItemRepository;
        }

        public ErrorOr<TodoItem> Create(CreateTodoItem request)
        {
            var createdItem = 
                _todoItemRepository.Create(
                    _mapper!.Map<TodoItem>(request));

            if (createdItem is null)
                return Errors.Repository.CreationFailed;

            return createdItem;
        }

        public ErrorOr<TodoItem> Delete(int id)
        {
            if (_todoItemRepository.Get(id) is null)
                return Errors.Repository.NotFound;

            var deleted = _todoItemRepository.Delete(id);

            if (deleted is null)
                return Errors.Repository.DeletionFailed;

            return deleted;
        }

        public ErrorOr<TodoItem?> Get(int id)
        {
            return _todoItemRepository.Get(id);
        }

        public ErrorOr<IEnumerable<TodoItem>> List(ListTodoItem request)
        {
            //TODO: query through dapper
            throw new NotImplementedException();
        }

        public ErrorOr<TodoItem> Update(UpdateTodoItem request)
        {
            var item = _todoItemRepository.Get(request.Id);

            if (item is null)
                return Errors.Repository.NotFound;

            item.TodoListId = request.ItemListId ?? item.TodoListId;
            item.Description = request.Description ?? item.Description;
            item.Done = request.Done ?? item.Done;

            var update = _todoItemRepository.Update(item);

            if (!update)
                return Errors.Repository.UpdateFailed;

            return item;
        }
    }
}
