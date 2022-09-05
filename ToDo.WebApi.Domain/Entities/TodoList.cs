using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Data.Entities;

namespace ToDo.WebApi.Domain.Entities
{
    public class TodoList : EntityBaseIncrementalId
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<TodoItem>? Items { get; set; }
    }
}
