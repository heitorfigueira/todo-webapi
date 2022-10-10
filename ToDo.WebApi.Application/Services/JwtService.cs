using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.WebApi.Application.Contracts.Services;
using WebApi.Framework.Data.Entities;
using WebApi.Framework.DependencyInjection;
using ToDo.WebApi.Domain;
using ErrorOr;
using ToDo.WebApi.Domain.Settings;

namespace ToDo.WebApi.Application.Services
{
    public class JwtService : TransientService, IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public ErrorOr<string> GenerateTokenFrom<TUser>(TUser user)
            where TUser : notnull, EntityBaseGUID
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = user.GetType()
                             .GetProperties()
                             .Where(prop => 
                                 prop.Name != "Password" && 
                                 prop.GetValue(user) is not null)
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

            if (token is null)
                return Errors.Authentication.CreationFailed;

            return tokenHandler.WriteToken(token);
        }

        public ErrorOr<Guid> ValidateToken(string token)
        {
            if (token is null)
                return Errors.Authentication.InvalidToken;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            SecurityToken validatedToken;

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                }, out validatedToken);
            }
            catch (Exception ex)
            {
                return Errors.Authentication.InvalidAuthorizationBearer;
            }
            
            var jwtToken = validatedToken as JwtSecurityToken;
            var userId = Guid.Parse(jwtToken!.Claims
                                   .FirstOrDefault(x => x.Type.ToLower() == "id")!.Value);

            return userId;
        }
    }
}
