using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.User
{
    public class UserGetTests
    {
        [Fact]
        public void Get_WithValidEmail_ReturnsUser()
        {
            // Arrange
            var (sut, user) = UserServiceSetups.GetValidEmailReturnsUser();

            // Act
            var result = sut.Get(user.Email);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(user);
        }

        [Fact]
        public void Get_WithInvalidEmail_ReturnsNull()
        {
            // Arrange
            var sut = UserServiceSetups.GetInvalidEmailReturnsNull();

            // Act
            var result = sut.Get(It.IsAny<string>());

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeNull();
        }
    }
}
