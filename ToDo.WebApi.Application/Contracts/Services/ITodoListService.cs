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
        TodoList? Create(CreateToDoList request);
        TodoList? Update(UpdateToDoList request);
        TodoList? Delete(int id);
        TodoList? Get(int id);
        IEnumerable<TodoList> List(ListToDoList request);
    }
}
