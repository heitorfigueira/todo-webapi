using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.TodoItem
{
    public class TodoItemGetTests
    {
        [Fact]
        public void Get_WithValidEmail_ReturnsTodoItem()
        {
            // Arrange
            var (sut, item) = TodoItemServiceSetups.GetValidIdReturnsTodoItem();

            // Act
            var result = sut.Get(item.Id);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(item);
        }

        [Fact]
        public void Get_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var sut = TodoItemServiceSetups.GetInvalidIdReturnsNull();

            // Act
            var result = sut.Get(It.IsAny<int>());

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeNull();
        }
    }
}
