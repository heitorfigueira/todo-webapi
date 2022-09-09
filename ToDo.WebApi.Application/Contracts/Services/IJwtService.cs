﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Data.Entities;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface IJwtService
    {
        string GenerateTokenFrom<T>(T user) where T : notnull, AuditableEntityBase<Guid>;
        int? ValidateToken(string token);
    }
}
