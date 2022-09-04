using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Entities;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_config["ConnectionStrings:DefaultDatabaseConnection"]);
        }
    }
}
