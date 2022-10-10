using ErrorOr;
using System.Collections.Generic;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Setups.Services;

namespace ToDo.WebApi.Tests.Unit.Application.Services.TodoList
{
    public class TodoListUpdateTests
    {
        [Fact]
        public void Update_OnSuccess_ReturnsTodoList()
        {
            // Arrange
            var (sut, list) = TodoListServiceSetups.UpdateReturnsTodoList();

            // Act
            var result = sut.Update(new(list.Id, null, null));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoList>>();
            result.IsError.Should().BeFalse();

            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(list);
        }

        [Fact]
        public void Update_OnFailure_ReturnsUpdateFailedError()
        {
            // Arrange
            var sut = TodoListServiceSetups.UpdateReturnsUpdateFailedError();

            // Act
            var result = sut.Update(new(8, null, null));

            // Assert
            result.Should().BeOfType<ErrorOr<WebApi.Domain.Entities.TodoList>>();
            result.IsError.Should().BeTrue();
            result.Errors.Should().Contain(Errors.Repository.UpdateFailed);
        }

    }
}
