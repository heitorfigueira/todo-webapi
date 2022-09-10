using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Setups.Services
{
    public static class UserRepositorySetups
    {
        public static Mock<IUserRepository> MockGetValidEmailReturnsUser(User user)
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(service =>
                    service.GetByEmail(user.Email))
                    .Returns(user);

            return mock;
        }

        //public static UserRepository GetValidEmailReturnsUser()
        //{

        //}
    }
}
