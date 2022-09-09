using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Interface.Controllers;
using ToDo.WebApi.Tests.Fakers;
using ToDo.WebApi.Tests.Handlers.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.Auth
{
    public class SigninTests
    {
        private AuthController? _sut { get; set; }

        [Fact]
        public void Signin_OnSuccess_ReturnsSession_WithStatus200()
        {
            #region Arrange
            var auth = AuthFakers.GenerateSingleAuth();

            _sut = AuthControllerHandler.SetupSigninValidCredentials(auth);
            #endregion

            #region Act
            var result = _sut.Signin(auth);
            #endregion

            #region Assert
            result.Should().BeOfType<OkObjectResult>();
            var session = (OkObjectResult) result;
            session.Value.Should().BeOfType<Session>();
            #endregion
        }
    }
}
