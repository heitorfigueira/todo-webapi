using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Enums;
using WebApi.Framework.Data.Entities;

namespace ToDo.WebApi.Domain.Entities
{
    public class Account : AuditableEntityBase<Guid>
    {
        public string Name { get; set; }
        public AccountTypes Type { get; set; }


        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<TodoList> Lists { get; set; }
    }
}
