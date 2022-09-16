﻿using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebApi.Domain;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials =
            Error.Unexpected(code: "Auth.InvalidCredentials",
                          description: "The user has provided invalid credentials.");

        public static Error DuplicateEmail =
            Error.Unexpected(code: "Auth.DuplicateEmail",
                          description: "This emails already belongs to another user.");

        public static Error CreationFailed =
            Error.Failure(code: "Auth.CreationFailed",
                          description: "An error occurred and it was not possible to create your user.");
    }

}