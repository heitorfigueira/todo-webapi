using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.TodoList
{
    public class ControllerGetTests
    {
        [Fact]
        public void Get_OnFailure_ReturnsNull_WithStatus200()
        {
            //Arrange
            var sut = TodoListControllerSetups.GetOnFailureReturnsNull();

            //Act
            var response = sut.Get(3);

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var accountR = (OkObjectResult)response;
            accountR.Value.Should().BeNull();
        }

        [Fact]
        public void Get_OnSuccess_ReturnsTodoList()
        {
            //Arrange
            var (sut, list) = TodoListControllerSetups.GetOnSuccessReturnsTodoList();

            //Act
            var response = sut.Get(3);

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var accountR = (OkObjectResult)response;
            accountR.Value.Should().BeOfType<WebApi.Domain.Entities.TodoList>();
            accountR.Value.Should().BeEquivalentTo(list);
        }
    }
}
