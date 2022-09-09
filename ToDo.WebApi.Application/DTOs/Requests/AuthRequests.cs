using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebApi.Application.DTOs.Requests
{
    public class AuthRequests
    {
        public record Auth(string Email, string Password);
    }
}
