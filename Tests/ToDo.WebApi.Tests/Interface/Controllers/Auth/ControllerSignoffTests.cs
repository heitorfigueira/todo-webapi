﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.Auth
{
    public class ControllerSignoffTests
    {
        [Fact]
        public void Signoff_OnSuccess_ReturnsSession_WithStatus200()
        {
            // Arrange
            //var (_sut, auth) = AuthControllerSetups.SigninWithValidCredentialsReturnsSession();

            // Act
            //var result = _sut.Signin(auth);

            // Assert
            Assert.False(true);
        }

        [Fact]
        public void Signoff_OnFailure_ReturnsProblemDetails_WithStatus400()
        {
            // Arrange
            //var (_sut, auth) = AuthControllerSetups.SigninInvalidCredentialsReturnsInvalidCredentialsError();

            // Act
            //var response = _sut.Signin(auth);

            // Assert
            Assert.False(true);
        }
    }
}
