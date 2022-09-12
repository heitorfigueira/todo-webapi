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
        ErrorOr<TodoList?> Create(CreateToDoList request);
        ErrorOr<TodoList?> Update(UpdateToDoList request);
        ErrorOr<TodoList?> Delete(int id);
        ErrorOr<TodoList?> Get(int id);
        ErrorOr<IEnumerable<TodoList>> List(ListToDoList request);
    }
}
