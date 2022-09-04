using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Enums;
using WebApi.Framework.DataAccess.Entities;

namespace ToDo.WebApi.Domain.Entities
{
    public class User : EntityBaseIncrementalId
    {
        public UserTypes Type { get; set; }
    }
}