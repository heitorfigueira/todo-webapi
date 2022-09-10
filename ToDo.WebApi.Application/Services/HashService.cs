using Konscious.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using System.Text;
using ToDo.WebApi.Application.Contracts.Services;

namespace ToDo.WebApi.Application.Services
{
    public class HashService : IHashService
    {
        private readonly IConfiguration _configuration;
        public readonly Argon2i argonHasher;

        public HashService(IConfiguration configuration, string passwordHasherEnvironmentVariable)
        {
            _configuration = configuration;
            argonHasher =
                new(Encoding.ASCII
                    .GetBytes(
                    _configuration[passwordHasherEnvironmentVariable]));
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
