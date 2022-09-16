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
    public interface ITodoItemService
    {
        ErrorOr<TodoItem> Create(CreateTodoItem request);
        ErrorOr<TodoItem> Update(UpdateTodoItem request);
        ErrorOr<TodoItem> Delete(int id);
        ErrorOr<TodoItem?> Get(int id);
        ErrorOr<IEnumerable<TodoItem>> List(ListTodoItem request);
    }
}
