using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface IHashService
    {
        string HashPassword(Guid salt, string password);
        bool VerifyAgainstHashedPassword(Guid userId, string hashedPassword, string providedPassword);
    }
}
