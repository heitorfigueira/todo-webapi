using ErrorOr;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.TodoItem
{
    public class UserDeleteTests
    {
        [Fact]
        public void Delete_OnSuccess_ReturnsDeletedUser()
        {
            // Arrange
            var (sut, item) = TodoItemServiceSetups.DeleteReturnsTodoItem();

            // Act
            var result = sut.Delete(item.Id);

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoItem>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(item);
        }

        [Fact]
        public void Delete_OnFailure_ReturnsDeletionFailedError()
        {
            // Arrange
            var sut = TodoItemServiceSetups.DeleteReturnsDeletionFailedError();

            // Act
            var result = sut.Delete(new());

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoItem>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.DeletionFailed);
        }
    }
}
