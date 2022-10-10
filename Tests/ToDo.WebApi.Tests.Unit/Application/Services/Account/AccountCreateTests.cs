using ErrorOr;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Domain.Enums;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.Account
{
    public class AccountCreateTests
    {
        [Fact]
        public void Create_OnSuccess_ReturnsAccount()
        {
            // Arrange
            var (sut, account) = AccountServiceSetups.CreateReturnsAccount();

            // Act
            var result = sut.Create(new(AccountTypes.Common, "", Guid.NewGuid()));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.Account>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(account);
        }

        [Fact]
        public void Create_OnFailure_ReturnsCreationFailedError()
        {
            // Arrange
            var sut = AccountServiceSetups.CreateReturnsCreationFailedError();

            // Act
            var result = sut.Create(new(AccountTypes.Common, "", Guid.NewGuid()));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.Account>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.CreationFailed);
        }

    }
}
