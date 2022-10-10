using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.TodoList
{
    public class TodoListGetTests
    {
        [Fact]
        public void Get_WithValidEmail_ReturnsTodoList()
        {
            // Arrange
            var (sut, list) = TodoListServiceSetups.GetValidIdReturnsTodoList();

            // Act
            var result = sut.Get(list.Id);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(list);
        }

        [Fact]
        public void Get_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var sut = TodoListServiceSetups.GetInvalidIdReturnsNull();

            // Act
            var result = sut.Get(It.IsAny<int>());

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeNull();
        }
    }
}
