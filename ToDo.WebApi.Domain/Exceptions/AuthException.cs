using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebApi.Domain.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException(string? message, Exception? innerException) : base(message, innerException)
        {
            if (String.IsNullOrEmpty(message))
                message = "An error occured in this autentication request";
        }
    }
}
