using ErrorOr;
using ToDo.WebApi.Tests.Domain.Setups.Repositories;

namespace ToDo.WebApi.Tests.Unit.Infrastructure.Repositories.User
{
    public class RepositoryGetByEmailTests
    {
        [Fact]
        public void GetByEmail_OnFailure_ReturnsNull()
        {
            //Arrange
            var sut = UserRepositorySetups.SetupGetByEmailInvalidEmailReturnsNull();

            //Act
            var result = sut.GetByEmail("");

            //Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.User>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().BeNull();
        }

        [Fact]
        public void GetByEmail_OnSuccess_ReturnsUser()
        {
            //Arrange
            var (sut, user) = UserRepositorySetups.SetupGetByEmailValidEmailReturnsUser();

            //Act
            var result = sut.GetByEmail(user.Email);

            //Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.User>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().BeEquivalentTo(user);
        }
    }
}
