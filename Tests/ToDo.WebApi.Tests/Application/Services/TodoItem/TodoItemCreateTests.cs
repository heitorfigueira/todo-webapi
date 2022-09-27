using ErrorOr;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.TodoItem
{
    public class TodoItemCreateTests
    {
        [Fact]
        public void Create_OnSuccess_ReturnsTodoItem()
        {
            // Arrange
            var (sut, item) = TodoItemServiceSetups.CreateReturnsTodoItem();

            // Act
            var result = sut.Create(new("", 0));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoItem>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(item);
        }

        [Fact]
        public void Create_OnFailure_ReturnsCreationFailedError()
        {
            // Arrange
            var sut = TodoItemServiceSetups.CreateReturnsCreationFailedError();

            // Act
            var result = sut.Create(new("", 0));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoItem>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.CreationFailed);
        }

    }
}
