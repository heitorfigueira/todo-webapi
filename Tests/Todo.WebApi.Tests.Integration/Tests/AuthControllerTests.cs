using AutoFixture;
using System.Net.Http.Json;
using ToDo.WebApi.Domain.Entities;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace Todo.WebApi.Tests.Integration.Tests
{
    [UsesVerify]
    public class AuthControllerTests : IClassFixture<TodoApiFactory>
    {
        private readonly HttpClient _httpClient;

        public AuthControllerTests(TodoApiFactory apiFactory)
        {
            _httpClient = apiFactory.CreateClient();
        }

        //[Fact]
        public async Task Signup_OnSuccess_Returns200()
        {
            // Arrange
            var request = new Fixture().Create<Auth>();

            // Act
            var response = await _httpClient.PostAsJsonAsync("auth/signup", request);

            // Assert
            var result = await response.Content.ReadFromJsonAsync<User>();
            await Verify(result);
        }
    }
}
