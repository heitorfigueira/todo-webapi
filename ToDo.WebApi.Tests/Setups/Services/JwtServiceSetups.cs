using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Setups.Services
{
    public static class JwtServiceSetups
    {
        public static Mock<IJwtService> MockGenerateTokenValidUserReturnsValidJwt(User user, string validJwt)
        {
            var mock = new Mock<IJwtService>();
            mock.Setup(service =>
                service.GenerateTokenFrom(user))
                .Returns(validJwt);

            return mock;
        }
    }
}
