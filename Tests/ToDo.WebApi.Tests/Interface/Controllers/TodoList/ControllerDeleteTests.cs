using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.TodoList
{
    public class ControllerDeleteTests
    {
        [Fact]
        public void Delete_OnFailure_ReturnsProblemDetails_WithStatus500()
        {
            //Arrange
            var sut = TodoListControllerSetups.DeleteOnFailureReturnsDeletionFailedError();

            //Act
            var response = sut.Delete(3);

            //Assert
            response.Should().BeOfType<ObjectResult>();

            var result = (ObjectResult)response;
            result.Value.Should().BeOfType<ProblemDetails>();
            result.StatusCode.Should().Be((int)StatusCodes.Status500InternalServerError);

            var problemDetails = (ProblemDetails)result.Value!;
            problemDetails.Status.Should().Be((int)StatusCodes.Status500InternalServerError);
        }

        [Fact]
        public void Delete_OnSuccess_ReturnsTodoList()
        {
            //Arrange
            var (sut, account) = TodoListControllerSetups.DeleteOnSuccessReturnsTodoList();

            //Act
            var response = sut.Delete(3);

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var accountR = (OkObjectResult)response;
            accountR.Value.Should().BeOfType<WebApi.Domain.Entities.TodoList>();
            accountR.Value.Should().BeEquivalentTo(account);
        }
    }
}
