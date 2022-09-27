using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Startup.Configurations
{
    public class SwaggerConfiguration : IInstaller, IMiddlewareInstaller
    {
        public int Order = 99;
        public int MiddlewareOrder = 99;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo WebAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = @"Enter 'Bearer' [space] and then your token in the text input below. Example: 'Bearer 12345abcdef'",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });
        }

        public void AddMiddlewareInstaller(WebApplication app)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
                RunDevelopmentSetup(app);
            else
                return;
        }

        private static void RunDevelopmentSetup(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
