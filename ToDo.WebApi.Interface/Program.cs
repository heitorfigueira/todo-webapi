using System.Reflection;
using ToDo.WebApi.Interface;
using WebApi.Framework.Extensions;

var builder = WebApplication.CreateBuilder(args);

var (services, configuration) = builder.GetServicesAndConfiguration();

var assemblies = AppDomain.CurrentDomain
                        .GetAssemblies()
                        .Where(ass => ass.FullName!
                                         .StartsWith("ToDo."))
                        .ToArray();

services.AddServicesFromAssemblies(configuration, assemblies);

services.AddInstallersFromAssemblies(configuration, assemblies);

var app = builder.Build();

app.AddMiddlewareInstallersFromAssemblies(assemblies);

app.Run();
