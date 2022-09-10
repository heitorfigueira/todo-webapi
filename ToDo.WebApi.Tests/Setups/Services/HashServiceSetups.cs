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
    public static class HashServiceSetups
    {
        public static Mock<IHashService> MockVerifyLoginAuthCorrectPasswordReturnsTrue(string authPassword, string userPassword)
        {
            var mock = new Mock<IHashService>();
            mock.Setup(service =>
                    service.VerifyAgainstHashedPassword(authPassword, userPassword))
                    .Returns(true);

            return mock;
        }
    }
}
