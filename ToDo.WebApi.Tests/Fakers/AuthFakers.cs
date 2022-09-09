using Bogus;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Fakers
{
    public static class AuthFakers
    {
        private static readonly Faker<Auth> _authFaker =
            new Faker<Auth>().CustomInstantiator(
                fake => new Auth(
                        fake.Person.Email, 
                        fake.Person.FirstName + fake.Random.Int()));

        public static Auth GenerateSingleAuth()
        {
            return _authFaker.Generate();
        }
        public static IEnumerable<Auth> GenerateAuth(int quantity)
        {
            return _authFaker.Generate(quantity);
        }
    }
}
