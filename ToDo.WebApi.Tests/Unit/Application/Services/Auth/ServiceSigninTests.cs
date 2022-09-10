using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Tests.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.Auth
{
    public class ServiceSigninTests
    {
        [Fact]
        public void Signin_OnSuccess_ReturnsSession()
        {
            // Arrange
            var (_sut, auth) = AuthServiceSetups.SigninValidCredentialsReturnsSessionValidJwt();

            // Act
            var result = _sut.Signin(auth);

            // Assert
            result.Should().BeOfType<Session>();
        }
    }
}
