using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApi.Framework.Data.Entities;

namespace ToDo.WebApi.Domain.Entities.Relations
{
    public class AccountTodoList : EntityBaseIdentity
    {
        public Guid AccountId { get; set; }
        public int TodoListId { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual TodoList TodoList { get; set; }
    }
}
