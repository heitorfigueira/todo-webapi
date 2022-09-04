using AutoMapper;
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
        private readonly IMapper _mapper;

        public TodoItemService(ITodoItemRepository todoListRepository, IMapper mapper)
        {
            _todoItemRepository = todoListRepository;
            _mapper = mapper;
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
    }
}
