using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;
using WebApi.Framework.Data.Repositories;

namespace ToDo.WebApi.Application.Contracts.Repositories
{
    public interface ITodoListRepository : IRepositoryIdentity<TodoList>
    {
    }
}
