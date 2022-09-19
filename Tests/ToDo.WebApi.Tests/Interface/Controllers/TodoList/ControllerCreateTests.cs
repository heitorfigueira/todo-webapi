using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.TodoList
{
    public class ControllerCreateTests
    {
        [Fact]
        public void Create_OnFailure_ReturnsProblemDetails_WithStatus500()
        {
            //Arrange
            var sut = TodoListControllerSetups.CreateOnFailureReturnsCreationFailedError();

            //Act
            var response = sut.Create(new("", Guid.NewGuid(), null, null));

            //Assert
            response.Should().BeOfType<ObjectResult>();

            var result = (ObjectResult)response;
            result.Value.Should().BeOfType<ProblemDetails>();
            result.StatusCode.Should().Be((int)StatusCodes.Status500InternalServerError);

            var problemDetails = (ProblemDetails)result.Value!;
            problemDetails.Status.Should().Be((int)StatusCodes.Status500InternalServerError);
        }

        [Fact]
        public void Create_OnSuccess_ReturnsTodoList()
        {
            //Arrange
            var (sut, list) = TodoListControllerSetups.CreateOnSuccessReturnsTodoList();

            //Act
            var response = sut.Create(new("", Guid.NewGuid(), null, null));

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var accountR = (OkObjectResult)response;
            accountR.Value.Should().BeOfType<WebApi.Domain.Entities.TodoList>();
            accountR.Value.Should().BeEquivalentTo(list);
        }
    }
}
