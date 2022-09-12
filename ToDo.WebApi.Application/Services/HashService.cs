using Konscious.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Settings;
using WebApi.Framework.DependencyInjection;

namespace ToDo.WebApi.Application.Services
{
    public class HashService : ScopedService, IHashService
    {
        private readonly AuthSettings _authSettings;

        public readonly Argon2i argonHasher;

        public HashService(IOptions<AuthSettings> options)
        {
            _authSettings = options.Value;
            argonHasher = new(Encoding.ASCII.GetBytes(_authSettings.Secret));
            argonHasher.Iterations = 10;
            argonHasher.DegreeOfParallelism = 1;
            argonHasher.MemorySize = 256;
        }

        public string HashPassword(string password)
        {
            return Encoding.ASCII.GetString(argonHasher.GetBytes(128));
        }

        public bool VerifyAgainstHashedPassword(string hashedPassword, string providedPassword)
        {
            return hashedPassword.Equals(HashPassword(providedPassword));
        }
    }
}
