using System.Reflection;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Settings;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Extensions;
using WebApi.Framework.Extensions.Logs;

var builder = WebApplication.CreateBuilder(args);

var (services, configuration) = builder.GetServicesAndConfiguration();

builder.UseSerilogFromConfigurationFile(configuration);

var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                          .Select(dll => Assembly.Load(AssemblyName.GetAssemblyName(dll)))
                          .Where(ass => ass.FullName!.StartsWith("ToDo."))
                          .ToArray();

services
    .Configure<AuthSettings>(configuration.GetSection(nameof(AuthSettings)))
    .Configure<ConnectionStringSettings>(configuration.GetSection(nameof(ConnectionStringSettings)))
    .Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

services//.ConfigureSettingsFromAssemblies(configuration, assemblies)
        .AddServicesFromAssemblies(configuration, assemblies)
        .AddInstallersFromAssemblies(configuration, assemblies);

var app = builder.Build();

app.AddMiddlewareInstallersFromAssemblies(assemblies);

app.Run();