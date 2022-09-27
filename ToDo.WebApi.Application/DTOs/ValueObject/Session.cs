using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebApi.Application.DTOs.ValueObject
{
    public class Session
    {
        public DateTime Started { get; set; }
        public DateTime Expires => Started.AddMinutes(15);
        public string Token { get; set; }
    }
}
