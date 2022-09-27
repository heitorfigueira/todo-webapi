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
using ToDo.WebApi.Domain;
using WebApi.Framework.DependencyInjection;
using System.Security.Principal;

namespace ToDo.WebApi.Application.Services
{
    public class TodoListService : TransientService, ITodoListService
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
        public ErrorOr<TodoList> Create(CreateTodoList request)
        {
            var createdList = _todoListRepository
                .Create(_mapper.Map<TodoList>(request));

            if (createdList is null)
                return Errors.Repository.CreationFailed;

            var failedCreations = new List<bool>();

            if (request.Items is not null && request.Items.Count() > 0)
                request.Items.ToList()
                    .ForEach(item => {
                        var created = _itemService.Create(item);

                        if (created.IsError || created.Value is null)
                            failedCreations.Add(false);
                    });

            if (failedCreations.Count > 0)
                return Errors.Repository.CreationFailed;

            var accountTodo = _accountTodoListRepository.Create(new()
            {
                AccountId = request.AccountId,
                TodoListId = createdList.Id
            });

            if (accountTodo is null)
                return Errors.Repository.CreationFailed;

            return createdList;
        }

        public ErrorOr<TodoList> Delete(int id)
        {
            var list = _todoListRepository.Get(id);

            if (list is null)
                return Errors.Repository.NotFound;

            var delete = _todoListRepository.Delete(id);

            if (delete is null)
                return Errors.Repository.DeletionFailed;

            return list;
        }

        public ErrorOr<TodoList?> Get(int id)
        {
            return _todoListRepository.Get(id);
        }

        public ErrorOr<IEnumerable<TodoList>> List(ListTodoList request)
        {
            //TODO: query through dapper
            throw new NotImplementedException();
        }

        public ErrorOr<TodoList> Update(UpdateTodoList request)
        {
            var list = _todoListRepository.Get(request.Id);

            if (list is null)
                return Errors.Repository.NotFound;

            list.Description = request.Description ?? list.Description;
            list.Name = request.Name ?? list.Name;
            
            var updated = _todoListRepository.Update(list);

            if (!updated)
                return Errors.Repository.UpdateFailed;

            return list;
        }
    }
}
