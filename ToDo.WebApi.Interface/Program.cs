using System.Reflection;
using ToDo.WebApi.Application.Fakers;
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

services.AddServicesFromAssemblies(configuration, assemblies);

services.AddInstallersFromAssemblies(configuration, assemblies);

var app = builder.Build();

app.AddMiddlewareInstallersFromAssemblies(assemblies);

app.Run();

var applicationContext = app.Services.CreateScope()
                                        .ServiceProvider.GetRequiredService<ApplicationContext>();

applicationContext.Add(UserFakers.GenerateUsers(200));