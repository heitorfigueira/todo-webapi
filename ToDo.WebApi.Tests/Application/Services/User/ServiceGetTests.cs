using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.User
{
    public class ServiceGetTests
    {
        [Fact]
        public void Get_WithValidEmail_ReturnsUser()
        {
            // Arrange
            var (_sut, user) = UserServiceSetups.GetValidEmailReturnsUser();

            // Act
            var result = _sut.Get(user.Email);

            // Assert
            result.Should().BeOfType<Domain.Entities.User>();
        }
    }
}
