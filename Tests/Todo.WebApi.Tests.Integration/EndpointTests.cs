using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Infrastructure.Contexts;

namespace Todo.WebApi.Tests.Integration
{
    public abstract class EndpointTests : IClassFixture<TodoApiFactory>
    {
        protected readonly HttpClient _httpClient;

        public EndpointTests(TodoApiFactory apiFactory)
        {
            _httpClient = apiFactory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions()
            {
                BaseAddress = new Uri("http://localhost:7090")
            });
        }
    }
}
