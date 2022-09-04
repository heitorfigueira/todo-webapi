﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.DataAccess.Entities;

namespace ToDo.WebApi.Domain.Entities
{
    public class TodoItem : EntityBaseIncrementalId
    {
        public string Description { get; set; }
        public bool Done { get; set; }


        [ForeignKey("TodoList")]
        public int TodoListId { get; set; }
        public virtual TodoList List { get; set; }
    }
}