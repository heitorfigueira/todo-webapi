using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Enums;

namespace ToDo.WebApi.Application.DTOs.Requests
{
    public record CreateAccount(AccountTypes Type, string Name, Guid UserId);
    public record UpdateAccount(Guid Id, AccountTypes? TypeId, string? Name);
    public record DeleteAccount(Guid Id);
}
