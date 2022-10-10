using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Tests.Unit.Setups.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.TodoItem
{
    public class ControllerGetTests
    {
        [Fact]
        public void Get_OnFailure_ReturnsNull_WithStatus200()
        {
            //Arrange
            var sut = TodoItemControllerSetups.GetOnFailureReturnsNull();

            //Act
            var response = sut.Get(3);

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var accountR = (OkObjectResult)response;
            accountR.Value.Should().BeNull();
        }

        [Fact]
        public void Get_OnSuccess_ReturnsTodoItem()
        {
            //Arrange
            var (sut, account) = TodoItemControllerSetups.GetOnSuccessReturnsTodoItem();

            //Act
            var response = sut.Get(3);

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var accountR = (OkObjectResult)response;
            accountR.Value.Should().BeOfType<WebApi.Domain.Entities.TodoItem>();
            accountR.Value.Should().BeEquivalentTo(account);
        }
    }
}
