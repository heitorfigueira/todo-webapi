using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebApi.Domain.Errors
{
    public static class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials =
                Error.Failure(code: "Auth.InvalidCredentials",
                              description: "The user has provided invalid credentials.");
        }
    }
}