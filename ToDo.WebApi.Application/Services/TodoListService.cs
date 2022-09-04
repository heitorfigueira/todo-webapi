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
    public class TodoListService : ScopedService, ITodoListService
    {
        private readonly ITodoItemService _itemService;
        private readonly ITodoListRepository _todoListRepository;

        public TodoListService(
            ITodoItemService itemService,
            ITodoListRepository todoListRepository,
            IMapper mapper) : 
            base(mapper)
        {
            _itemService = itemService;
            _todoListRepository = todoListRepository;
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

        public TodoList? Delete(int id)
        {
            var list = _todoListRepository.Get(id);

            _todoListRepository.Delete(id);

            return list;
        }

        public TodoList? Get(int id)
        {
            return _todoListRepository.Get(id);
        }

        public IEnumerable<TodoList> List(ListToDoList request)
        {
            //TODO: query through dapper
            throw new NotImplementedException();
        }

        public TodoList? Update(UpdateToDoList request)
        {
            return _todoListRepository.Update(request.list) ? request.list : null;
        }
    }
}
