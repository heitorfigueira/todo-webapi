using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Tests.Unit.Setups.Controllers;

namespace ToDo.WebApi.Tests.Unit.Interface.Controllers.Account
{
    public class ControllerCreateTests
    {
        [Fact]
        public void Create_OnFailure_ReturnsProblemDetails_WithStatus500()
        {
            //Arrange
            var sut = AccountControllerSetups.CreateOnFailureReturnsCreationFailedError();

            //Act
            var response = sut.Create(new(WebApi.Domain.Enums.AccountTypes.Common, "", Guid.NewGuid()));

            //Assert
            response.Should().BeOfType<ObjectResult>();

            var result = (ObjectResult) response;
            result.Value.Should().BeOfType<ProblemDetails>();
            result.StatusCode.Should().Be((int)StatusCodes.Status500InternalServerError);

            var problemDetails = (ProblemDetails)result.Value!;
            problemDetails.Status.Should().Be((int)StatusCodes.Status500InternalServerError);
        }

        [Fact]
        public void Create_OnSuccess_ReturnsAccount()
        {
            //Arrange
            var (sut, account) = AccountControllerSetups.CreateOnSuccessReturnsAccount();

            //Act
            var response = sut.Create(new(WebApi.Domain.Enums.AccountTypes.Common, "", Guid.NewGuid()));

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var accountR = (OkObjectResult) response;
            accountR.Value.Should().BeOfType<WebApi.Domain.Entities.Account>();
            accountR.Value.Should().BeEquivalentTo(account);
        }
    }
}
