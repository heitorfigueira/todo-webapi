using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Tests.Unit.Setups.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.Account
{
    public class ControllerGetTests
    {
        [Fact]
        public void Get_OnFailure_ReturnsNull_WithStatus200()
        {
            //Arrange
            var sut = AccountControllerSetups.GetOnFailureReturnsNull();

            //Act
            var response = sut.Get(Guid.NewGuid());

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var accountR = (OkObjectResult)response;
            accountR.Value.Should().BeNull();
        }

        [Fact]
        public void Get_OnSuccess_ReturnsAccount()
        {
            //Arrange
            var (sut, account) = AccountControllerSetups.GetOnSuccessReturnsAccount();

            //Act
            var response = sut.Get(Guid.NewGuid());

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var accountR = (OkObjectResult)response;
            accountR.Value.Should().BeOfType<WebApi.Domain.Entities.Account>();
            accountR.Value.Should().BeEquivalentTo(account);
        }
    }
}
