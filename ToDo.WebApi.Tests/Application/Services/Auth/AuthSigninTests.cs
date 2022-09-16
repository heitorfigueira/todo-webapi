using ErrorOr;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.Auth
{
    public class AuthSigninTests
    {
        [Fact]
        public void Signin_OnSuccess_ReturnsSession()
        {
            // Arrange
            var (_sut, request) = AuthServiceSetups.SigninValidCredentialsReturnsSession();

            // Act
            var result = _sut.Signin(request);

            // Assert
            result.Should().BeOfType<ErrorOr<Session>>();
            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<Session>();
        }

        [Fact]
        public void Signin_WithInvalidEmail_ReturnsInvalidCredentialsError()
        {
            // Arrange
            var (_sut, request) = AuthServiceSetups.SigninInvalidEmailReturnsInvalidCredentialsError();

            // Act
            var result = _sut.Signin(request);

            // Assert
            result.Should().BeOfType<ErrorOr<Session>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Authentication.InvalidCredentials);
        }

        [Fact]
        public void Signin_WithIncorrectPassword_ReturnsInvalidCredentialsError()
        {
            // Arrange
            var (_sut, request) = AuthServiceSetups.SigninIncorrectPasswordReturnsInvalidCredentialsError();

            // Act
            var result = _sut.Signin(request);

            // Assert
            result.Should().BeOfType<ErrorOr<Session>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Authentication.InvalidCredentials);
        }
    }
}
