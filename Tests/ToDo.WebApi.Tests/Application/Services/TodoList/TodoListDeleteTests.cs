using ErrorOr;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.TodoList
{
    public class TodoListDeleteTests
    {
        [Fact]
        public void Delete_OnSuccess_ReturnsDeletedUser()
        {
            // Arrange
            var (sut, list) = TodoListServiceSetups.DeleteReturnsTodoList();

            // Act
            var result = sut.Delete(list.Id);

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoList>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(list);
        }

        [Fact]
        public void Delete_OnFailure_ReturnsDeletionFailedError()
        {
            // Arrange
            var sut = TodoListServiceSetups.DeleteReturnsDeletionFailedError();

            // Act
            var result = sut.Delete(new());

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoList>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.DeletionFailed);
        }
    }
}
