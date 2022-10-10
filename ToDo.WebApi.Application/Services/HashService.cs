using Konscious.Security.Cryptography;
using Microsoft.Extensions.Options;
using System.Text;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Domain.Settings;
using WebApi.Framework.DependencyInjection;

namespace ToDo.WebApi.Application.Services
{
    public class HashService : SingletonService, IHashService
    {
        private readonly AuthSettings _authSettings;

        public HashService(IOptions<AuthSettings> options)
        {
            _authSettings = options.Value;
        }

        public string HashPassword(Guid salt, string password)
        {
            Argon2i argonHasher = new(Encoding.ASCII.GetBytes(password));

            argonHasher.DegreeOfParallelism = _authSettings.DegreeOfParallelism;
            argonHasher.Iterations = _authSettings.Iterations;
            argonHasher.MemorySize = _authSettings.MemorySize;

            argonHasher.Salt = Encoding.ASCII.GetBytes(salt.ToString());
            argonHasher.KnownSecret = Encoding.ASCII.GetBytes(_authSettings.Secret);

            return Convert.ToHexString(argonHasher.GetBytes(128));
        }

        public bool VerifyAgainstHashedPassword(Guid userId, string hashedPassword, string providedPassword)
        {
            var providedPasswordHash = HashPassword(userId, providedPassword);

            return hashedPassword.Equals(providedPasswordHash);
        }
    }
}
