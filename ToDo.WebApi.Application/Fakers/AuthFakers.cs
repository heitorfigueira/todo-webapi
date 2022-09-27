using Bogus;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Application.Fakers
{
    public static class AuthFakers
    {
        private static readonly Faker<Auth> _authFaker =
            new Faker<Auth>().CustomInstantiator(
                fake => new Auth(
                        fake.Person.Email,
                        fake.Random.Word().ToUpper() + "!!" + fake.Random.Number(0, 10_000)));

        public static Faker<Auth> InternalFaker()
        {
            return _authFaker;
        }

        public static Auth GenerateSingleAuth()
        {
            return InternalFaker().Generate();
        }
        public static IEnumerable<Auth> GenerateAuth(int quantity)
        {
            return InternalFaker().Generate(quantity);
        }
    }
}
