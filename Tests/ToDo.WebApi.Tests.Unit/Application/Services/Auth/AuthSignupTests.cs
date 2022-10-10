using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.Auth
{
    public class AuthSignupTests
    {
        [Fact]
        public void Signup_OnSuccess_ReturnsSession()
        {
            // Arrange
            var (_sut, request) = AuthServiceSetups.SignupValidCredentialsReturnsSession();

            // Act
            var result = _sut.Signup(request);

            // Assert
            result.Should().BeOfType<ErrorOr<Session>>();
            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<Session>();
        }

        [Fact]
        public void Signup_WithDuplicateEmail_ReturnsDuplicateEmailError()
        {
            // Arrange
            var sut = AuthServiceSetups.SignupWithDuplicateEmailReturnsDuplicateEmailErrors();

            // Act
            var result = sut.Signup(new("", ""));

            // Assert
            result.Should().BeOfType<ErrorOr<Session>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Authentication.DuplicateEmail);
        }

        [Fact]
        public void Signup_OnAuthCreationFailure_ReturnsCreationFailureError()
        {
            // Arrange
            var (sut, auth) = AuthServiceSetups.SignupOnAuthCreationFailureReturnsAuthCreationFailedError();

            // Act
            var result = sut.Signup(auth);

            // Assert
            result.Should().BeOfType<ErrorOr<Session>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Authentication.CreationFailed);
        }

        [Fact]
        public void Signup_OnUserCreationFailure_ReturnsCreationFailureError()
        {
            // Arrange
            var (sut, auth) = AuthServiceSetups.SignupOnUserCreationFailureReturnsCreationFailedError();

            // Act
            var result = sut.Signup(auth);

            // Assert
            result.Should().BeOfType<ErrorOr<Session>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.CreationFailed);
        }
    }
}
