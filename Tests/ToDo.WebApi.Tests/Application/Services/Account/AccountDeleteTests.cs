using ErrorOr;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.Account
{
    public class UserDeleteTests
    {
        [Fact]
        public void Delete_OnSuccess_ReturnsDeletedUser()
        {
            // Arrange
            var (sut, account) = AccountServiceSetups.DeleteReturnsAccount();

            // Act
            var result = sut.Delete(account.Id);

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.Account>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(account);
        }

        [Fact]
        public void Delete_OnFailure_ReturnsDeletionFailedError()
        {
            // Arrange
            var sut = AccountServiceSetups.DeleteReturnsDeletionFailedError();

            // Act
            var result = sut.Delete(new());

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.Account>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.DeletionFailed);
        }
    }
}
