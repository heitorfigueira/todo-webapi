using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface ITodoListService
    {
        ErrorOr<TodoList> Create(CreateTodoList request);
        ErrorOr<TodoList> Update(UpdateTodoList request);
        ErrorOr<TodoList> Delete(int id);
        ErrorOr<TodoList?> Get(int id);
        ErrorOr<IEnumerable<TodoList>> List(ListTodoList request);
    }
}
