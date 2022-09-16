using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApi.Framework.Data.Entities;

namespace ToDo.WebApi.Domain.Entities
{
    public class TodoItem : EntityBaseIdentity
    {
        public string Description { get; set; }
        public bool Done { get; set; }


        [ForeignKey("TodoList")]
        public int TodoListId { get; set; }
        [JsonIgnore]
        public virtual TodoList List { get; set; }
    }
}
