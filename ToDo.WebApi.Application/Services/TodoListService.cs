using AutoMapper;
using ErrorOr;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Repositories;
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
        
        private readonly IAccountTodoListRepository _accountTodoListRepository;

        public TodoListService(
            ITodoItemService itemService,
            ITodoListRepository todoListRepository,
            IAccountTodoListRepository accountTodoListRepository, 
            IMapper mapper) :
            base(mapper)
        {
            _itemService = itemService;
            _todoListRepository = todoListRepository;
            _accountTodoListRepository = accountTodoListRepository;
        }
        public ErrorOr<TodoList> Create(CreateToDoList request)
        {
            TodoList? list = null;
            var createdListId = _todoListRepository
                .Create(_mapper.Map<TodoList>(request));

            if (createdListId > 0 &&
                request.Items is not null &&
                request.Items.Count() > 0)
            {
                request.Items
                    .ToList().ForEach(item => 
                    _itemService.Create(item));

                _accountTodoListRepository.Create(new()
                {
                    AccountId = request.accountId,
                    TodoListId = createdListId
                });

                list = _todoListRepository.Get(createdListId);
            }

            return list;
        }

        public ErrorOr<TodoList?> Delete(int id)
        {
            var list = _todoListRepository.Get(id);

            _todoListRepository.Delete(id);

            return list;
        }

        public ErrorOr<TodoList?> Get(int id)
        {
            return _todoListRepository.Get(id);
        }

        public ErrorOr<IEnumerable<TodoList>> List(ListToDoList request)
        {
            //TODO: query through dapper
            throw new NotImplementedException();
        }

        public ErrorOr<TodoList?> Update(UpdateToDoList request)
        {
            return _todoListRepository.Update(request.list) ? request.list : null;
        }
    }
}
