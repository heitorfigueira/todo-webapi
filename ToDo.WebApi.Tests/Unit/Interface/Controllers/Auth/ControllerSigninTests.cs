using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Tests.Setups.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.Auth
{
    public class ControllerSigninTests
    {
        [Fact]
        public void Signin_OnSuccess_ReturnsSession_WithStatus200()
        {
            // Arrange
            var (_sut, auth) = AuthControllerSetups.SigninValidCredentialsReturnsSession();

            // Act
            var result = _sut.Signin(auth);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var session = (OkObjectResult) result;
            session.Value.Should().BeOfType<Session>();
        }
    }
}
