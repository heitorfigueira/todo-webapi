using ErrorOr;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.User
{
    public class UserDeleteTests
    {
        [Fact]
        public void Delete_OnSuccess_ReturnsDeletedUser()
        {
            // Arrange
            var (sut, user) = UserServiceSetups.DeleteReturnsUser();

            // Act
            var result = sut.Delete(user.Id);

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.User>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(user);
        }

        [Fact]
        public void Delete_OnFailure_ReturnsDeletionFailedError()
        {
            // Arrange
            var sut = UserServiceSetups.DeleteReturnsDeletionFailedError();

            // Act
            var result = sut.Delete(new());

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.User>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.DeletionFailed);
        }
    }
}
