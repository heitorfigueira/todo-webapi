using System.Reflection;
using WebApi.Framework.Extensions;
using WebApi.Framework.Extensions.Logs;

var builder = WebApplication.CreateBuilder(args);

var (services, configuration) = builder.GetServicesAndConfiguration();

builder.UseSerilog(configuration);

var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                          .Select(dll => Assembly.Load(AssemblyName.GetAssemblyName(dll)))
                          .Where(ass => ass.FullName!.StartsWith("ToDo."))
                          .ToArray();

services.AddServicesFromAssemblies(configuration, assemblies);

services.AddInstallersFromAssemblies(configuration, assemblies);

var app = builder.Build();

app.AddMiddlewareInstallersFromAssemblies(assemblies);

app.Run();
