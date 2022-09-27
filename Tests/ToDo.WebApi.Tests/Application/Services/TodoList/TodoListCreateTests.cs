using ErrorOr;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.TodoList
{
    public class TodoListCreateTests
    {
        [Fact]
        public void Create_OnSuccess_ReturnsTodoList()
        {
            // Arrange
            var (sut, list) = TodoListServiceSetups.CreateReturnsTodoList();

            // Act
            var result = sut.Create(new("", Guid.NewGuid(), null, null));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoList>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(list);
        }

        [Fact]
        public void Create_OnFailure_ReturnsCreationFailedError()
        {
            // Arrange
            var sut = TodoListServiceSetups.CreateReturnsCreationFailedError();

            // Act
            var result = sut.Create(new("", Guid.NewGuid(), null, null));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoList>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.CreationFailed);
        }

    }
}
