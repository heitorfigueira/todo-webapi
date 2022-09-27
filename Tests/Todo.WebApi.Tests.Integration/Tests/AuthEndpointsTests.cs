using AutoFixture;
using Bogus;
using FluentAssertions;
using System.Net.Http.Json;
using System.Text.Json;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Domain.Entities;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace Todo.WebApi.Tests.Integration.Tests
{
    public class AuthEndpointsTests : EndpointTests
    {
        public AuthEndpointsTests(TodoApiFactory apiFactory) : base(apiFactory)
        {
        }
    }
}
