using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class AuthConfiguration : IInstaller, IMiddlewareInstaller
    {
        public int InstallerOrder = 4;
        public int MiddlewareOrder = 3;

        public void AddMiddlewareInstaller(WebApplication app)
        {
            app.UseAuthorization();
            app.UseAuthentication();
        }
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => options.TokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]))
            });
        }
    }
}
