using ErrorOr;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.TodoItem
{
    public class TodoItemUpdateTests
    {
        [Fact]
        public void Update_OnSuccess_ReturnsTodoItem()
        {
            // Arrange
            var (sut, item) = TodoItemServiceSetups.UpdateReturnsTodoItem();

            // Act
            var result = sut.Update(new(0, null, null, null));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoItem>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(item);
        }

        [Fact]
        public void Update_OnFailure_ReturnsUpdateFailedError()
        {
            // Arrange
            var (sut, account) = TodoItemServiceSetups.UpdateReturnsUpdateFailedError();

            // Act
            var result = sut.Update(new(0, null, null, null));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoItem>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.UpdateFailed);
        }

    }
}
