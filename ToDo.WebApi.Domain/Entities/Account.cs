using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Enums;
using WebApi.Framework.Data.Entities;

namespace ToDo.WebApi.Domain.Entities
{
    public class Account : AuditableEntityBase<Guid, Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public AccountTypes TypeId { get; set; }

        public override Guid CreatedBy { get; set; }
        public override Guid UpdatedBy { get; set; }

        [JsonIgnore]
        public virtual AccountType AccountType { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<TodoList> Lists { get; set; }
    }
}
