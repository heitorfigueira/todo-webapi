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
    public class TodoListService : ScopedService, ITodoListService
    {
        private readonly ITodoItemService _itemService;
        private readonly ITodoListRepository _todoListRepository;
        private readonly IMapper _mapper;

        public TodoListService(
            ITodoItemService itemService,
            ITodoListRepository todoListRepository,
            IMapper mapper)
        {
            _itemService = itemService;
            _todoListRepository = todoListRepository;
            _mapper = mapper;
        }

        public TodoList Create(CreateToDoList request)
        {
            TodoList? list = null;
            var createdListId = _todoListRepository.Create(_mapper.Map<TodoList>(request));

            if (createdListId > 0 &&
                request.Items is not null &&
                request.Items.Count() > 0)
            {
                request.Items
                    .ToList().ForEach(item => 
                    _itemService.Create(item));
            
                list = _todoListRepository.Get(createdListId);
            }

            return list;
        }
    }
}
