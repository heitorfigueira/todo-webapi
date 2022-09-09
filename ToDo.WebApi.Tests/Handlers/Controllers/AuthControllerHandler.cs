using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Interface.Controllers;
using ToDo.WebApi.Tests.Fakers;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Handlers.Controllers
{
    public static class AuthControllerHandler
    {
        public static AuthController SetupSigninValidCredentials(Auth validAuth)
        {
            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(s =>
                s.Signin(validAuth))
                .Returns(new Session());

            return new AuthController(mockAuthService.Object);
        }
    }
}
