using ErrorOr;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.User
{
    public class UserCreateTests
    {
        [Fact]
        public void Create_OnSuccess_ReturnsUser()
        {
            // Arrange
            var (sut, user) = UserServiceSetups.CreateReturnsUser();

            // Act
            var result = sut.Create(user);

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.User>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(user);
        }

        [Fact]
        public void Create_OnFailure_ReturnsCreationFailedError()
        {
            // Arrange
            var sut = UserServiceSetups.CreateReturnsCreationFailedError();

            // Act
            var result = sut.Create(new());

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.User>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.CreationFailed);
        }

    }
}
