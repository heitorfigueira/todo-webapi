using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;
using WebApi.Framework.DependencyInjection;

namespace ToDo.WebApi.Application.Services
{
    public class TodoItemService : ScopedService, ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(
            IMapper mapper, 
            ITodoItemRepository todoItemRepository) : 
            base(mapper)
        {
            _todoItemRepository = todoItemRepository;
        }

        public TodoItem Create(CreateToDoItem request)
        {
            TodoItem? item = null;
            var createdListId = 
                _todoItemRepository.Create(
                    _mapper.Map<TodoItem>(request));

            if (createdListId > 0)
                item = _todoItemRepository.Get(createdListId);

            return item;
        }

        public TodoItem? Delete(int id)
        {
            var item = _todoItemRepository.Get(id);

            _todoItemRepository.Delete(id);

            return item;
        }

        public TodoItem? Get(int id)
        {
            return _todoItemRepository.Get(id);
        }

        public IEnumerable<TodoItem> List(ListToDoItem request)
        {
            //TODO: query through dapper
            throw new NotImplementedException();
        }

        public TodoItem? Update(UpdateToDoItem request)
        {
            return _todoItemRepository.Update(request.item) ? request.item : null;
        }
    }
}
