using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Entities.Relations;

namespace ToDo.WebApi.Infrastructure.Contexts
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _config;

        public ApplicationContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<AccountTodoList> AccountTodoList { get; set; }
    } 
}
