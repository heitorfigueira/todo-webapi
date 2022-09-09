﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface IPasswordService
    {
        bool VerifyLogin(Auth auth, string hashedPassword);
        string HashPassword(string password);
    }
}
