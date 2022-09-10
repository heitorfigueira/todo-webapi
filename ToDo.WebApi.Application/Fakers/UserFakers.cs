using Bogus;
using ToDo.WebApi.Domain.Entities;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Application.Fakers
{
    public static class UserFakers
    {
        private static readonly Faker<User> _userFaker =
            new Faker<User>().CustomInstantiator(
                fake => new User()
                {
                    Email = fake.Person.Email,
                    Password = fake.Person.FirstName + fake.Random.Int()
                });

        public static User GenerateSingleUser()
        {
            return _userFaker.Generate();
        }
        public static IEnumerable<User> GenerateUsers(int quantity)
        {
            return _userFaker.Generate(quantity);
        }
    }
}
