using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.Auth
{
    public class ControllerSigninTests
    {
        [Fact]
        public void Signin_OnSuccess_ReturnsSession_WithStatus200()
        {
            // Arrange
            var (_sut, auth) = AuthControllerSetups.SigninWithValidCredentialsReturnsSession();

            // Act
            var result = _sut.Signin(auth);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var session = (OkObjectResult) result;
            session.Value.Should().BeOfType<Session>();
        }

        [Fact]
        public void Signin_OnFailure_ReturnsProblemDetails_WithStatus400()
        {
            // Arrange
            var (_sut, auth) = AuthControllerSetups.SigninInvalidCredentialsReturnsInvalidCredentialsError();

            // Act
            var response = _sut.Signin(auth);

            // Assert
            response.Should().BeOfType<ObjectResult>();

            var result = (ObjectResult) response;
            result.Value.Should().BeOfType<ProblemDetails>();
            result.StatusCode.Should().Be((int)StatusCodes.Status400BadRequest);

            var problemDetails = (ProblemDetails) result.Value!;
            problemDetails.Status.Should().Be((int) StatusCodes.Status400BadRequest);
        }
    }
}
