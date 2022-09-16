using ErrorOr;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.Account
{
    public class AccountUpdateTests
    {
        [Fact]
        public void Update_OnSuccess_ReturnsAccount()
        {
            // Arrange
            var (sut, account) = AccountServiceSetups.UpdateReturnsAccount();

            // Act
            var result = sut.Update(new(account.Id, null, null));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.Account>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(account);
        }

        [Fact]
        public void Update_OnFailure_ReturnsUpdateFailedError()
        {
            // Arrange
            var (sut, account) = AccountServiceSetups.UpdateReturnsUpdateFailedError();

            // Act
            var result = sut.Update(new(Guid.NewGuid(), null, null));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.Account>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.UpdateFailed);
        }

    }
}
