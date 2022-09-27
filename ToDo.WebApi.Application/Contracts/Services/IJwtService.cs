using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Data.Entities;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface IJwtService
    {
        ErrorOr<string> GenerateTokenFrom<T>(T user) where T : notnull, EntityBaseGUID;
        ErrorOr<Guid> ValidateToken(string token);
    }
}
