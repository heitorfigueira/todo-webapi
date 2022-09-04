﻿using System;
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
        TodoItem? Create(CreateToDoItem request);
        TodoItem? Update(UpdateToDoItem request);
        TodoItem? Delete(int id);
        TodoItem? Get(int id);
        IEnumerable<TodoItem> List(ListToDoItem request);
    }
}
