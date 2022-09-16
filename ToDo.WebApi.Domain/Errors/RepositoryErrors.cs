using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebApi.Domain;

public static partial class Errors
{
    public static class Repository
    {
        public static Error CreationFailed =
            Error.Failure(code: "Repository.CreationFailed",
                          description: "An error occurred and it was not possible to finish the resource creation.");

        public static Error DeletionFailed =
            Error.Failure(code: "Repository.DeletionFailed",
                          description: "An error occurred and it was not possible to finish the resource deletion.");

        public static Error UpdateFailed =
            Error.Failure(code: "Repository.UpdateFailed",
                          description: "An error occurred and it was not possible to finish the resource update.");

        public static Error NotFound =
            Error.Failure(code: "Repository.NotFound",
                            description: "The specific resource you were looking for couldn't be found.");

        public static class Connection
        {
            public static Error Lost =
                Error.Failure(code: "Repository.ConnectionLost",
                              description: "An error occurred and it was not possible to finish the resource creation.");

            public static Error Failed =
                Error.Failure(code: "Repository.ConnectionFailed",
                              description: "An error occurred.");

            public static Error Refused =
                Error.Failure(code: "Repository.ConnectionRefused",
                              description: "An error occurred.");

            public static Error Timeout =
                Error.Failure(code: "Repository.ConnectionTimeout",
                              description: "An error occurred.");
        }
    }
}

