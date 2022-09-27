using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Enums;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Application.Fakers
{
    public static class AccountFakers
    {
        private static Faker<Account> _faker =
            new Faker<Account>().CustomInstantiator(
                            fake => new()
                            {
                                Id = fake.Random.Guid(),
                                Name = fake.Person.FullName,
                                TypeId = AccountTypes.Common,
                                Created = DateTime.UtcNow
                            });

        public static Faker<Account> InternalFakerSetup()
        {
            return _faker;
        }
        public static Account GenerateAccountTypeToUser(Guid userId, AccountTypes type)
        {
            return CreateFakerWith(userId, type).Generate();
        }
        public static Account GenerateAccountType(AccountTypes type)
        {
            var user = UserFakers.GenerateSingleUser();

            return GenerateAccountTypeToUser(user.Id, type);
        }
        private static Faker<Account> CreateFakerWith(Guid userId, AccountTypes type)
        {
            return _faker
                        .RuleFor(user => user.CreatedBy, userId)
                        .RuleFor(user => user.UserId, userId)
                        .RuleFor(user => user.TypeId, faker => type);
        }
    }
}
