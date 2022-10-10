using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.TodoItem
{
    public class ControllerCreateTests
    {
        [Fact]
        public void Create_OnFailure_ReturnsProblemDetails_WithStatus500()
        {
            //Arrange
            var sut = TodoItemControllerSetups.CreateOnFailureReturnsCreationFailedError();

            //Act
            var response = sut.Create(new("", 4));

            //Assert
            response.Should().BeOfType<ObjectResult>();

            var result = (ObjectResult)response;
            result.Value.Should().BeOfType<ProblemDetails>();
            result.StatusCode.Should().Be((int)StatusCodes.Status500InternalServerError);

            var problemDetails = (ProblemDetails)result.Value!;
            problemDetails.Status.Should().Be((int)StatusCodes.Status500InternalServerError);
        }

        [Fact]
        public void Create_OnSuccess_ReturnsTodoItem()
        {
            //Arrange
            var (sut, item) = TodoItemControllerSetups.CreateOnSuccessReturnsTodoItem(3);

            //Act
            var response = sut.Create(new("", 3));

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var accountR = (OkObjectResult)response;
            accountR.Value.Should().BeOfType<WebApi.Domain.Entities.TodoItem>();
            accountR.Value.Should().BeEquivalentTo(item);
        }
    }
}
