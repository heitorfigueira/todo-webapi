using Microsoft.AspNetCore.Mvc.Testing;
using ToDo.WebApi.Interface.Controllers;

namespace Todo.WebApi.Tests.Integration
{
    public class TodoApiFactory : WebApplicationFactory<AuthController>
    {
    }
}
