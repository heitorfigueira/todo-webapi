using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Enums;
using WebApi.Framework.Data.Entities;

namespace ToDo.WebApi.Domain.Entities
{
    public class User : EntityBaseGUID
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }

        //[JsonIgnore]
        //public virtual Account? Account { get; set; }
    }
}