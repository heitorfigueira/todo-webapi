using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Settings;
using WebApi.Framework.Data.Entities;
using WebApi.Framework.DependencyInjection;

namespace ToDo.WebApi.Application.Services
{
    public class JwtService : ScopedService, IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;

        public JwtService(IConfiguration configuration, IOptions<JwtSettings> options)
        {
            _configuration = configuration;
            _jwtSettings = options.Value;
        }

        public string GenerateTokenFrom<TUser>(TUser user)
            where TUser : notnull, AuditableEntityBase<Guid>
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = user.GetType()
                             .GetProperties()
                             .Where(prop => 
                                 prop.Name != "Password")
                             .Select(prop => 
                                 new Claim(
                                    prop.Name, 
                                    prop.GetValue(user)!.ToString()!))
                             .ToArray();



            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtSettings.Issuer,
                // TODO: Audience = "",
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                SigningCredentials = new SigningCredentials(
                                        new SymmetricSecurityKey(key), 
                                        SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public int? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken;
            var userId = int.Parse(jwtToken!.Claims
                                   .FirstOrDefault(x => x.Type == "id")!.Value);

            return userId;
        }
    }
}
