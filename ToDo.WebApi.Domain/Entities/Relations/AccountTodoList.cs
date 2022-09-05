using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Data.Entities;

namespace ToDo.WebApi.Domain.Entities.Relations
{
    public class AccountTodoList : EntityBaseIncrementalId
    {
        public Guid AccountId { get; set; }
        public int TodoListId { get; set; }

        public virtual Account Account { get; set; }
        public virtual TodoList TodoList { get; set; }
    }
}
