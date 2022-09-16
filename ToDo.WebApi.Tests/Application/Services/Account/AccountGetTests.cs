using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.Account
{
    public class AccountGetTests
    {
        [Fact]
        public void Get_WithValidEmail_ReturnsAccount()
        {
            // Arrange
            var (sut, user) = AccountServiceSetups.GetValidIdReturnsAccount();

            // Act
            var result = sut.Get(user.Id);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(user);
        }

        [Fact]
        public void Get_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var sut = AccountServiceSetups.GetInvalidIdReturnsNull();

            // Act
            var result = sut.Get(It.IsAny<Guid>());

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeNull();
        }
    }
}
