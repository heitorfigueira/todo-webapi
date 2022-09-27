using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain.Endpoints;

namespace Todo.WebApi.Tests.Integration.Snapshots
{
    [UsesVerify]
    public class AuthEndpointsSnapshots : EndpointTests
    {
        public AuthEndpointsSnapshots(TodoApiFactory apiFactory) : base(apiFactory)
        {
        }

        [Fact]
        public async Task Signup_OnSuccess_Returns200WithSession()
        {
            // Arrange
            var request = new Auth("admin2@admin.adm", "SuperAdmin!234");

            // Act
            var response = await _httpClient.PostAsJsonAsync(Endpoints.Auth.Signup, request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<Session>();

            await Verify(result);
        }

        [Fact]
        public async Task Signin_OnSuccess_Returns200WithSession()
        {
            // Arrange
            var request = new Auth("admin2@admin.adm", "SuperAdmin!234");

            // Act
            var response = await _httpClient.PostAsJsonAsync(Endpoints.Auth.Signin, request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<Session>();

            await Verify(result);
        }
    }
}
