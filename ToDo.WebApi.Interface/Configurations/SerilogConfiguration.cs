using Serilog.Events;
using Serilog.Filters;
using Serilog;
using WebApi.Framework.Installers;

namespace ToDo.WebApi.Interface.Configurations
{
    public class SerilogConfiguration : IMiddlewareInstaller
    {
        public int MiddlewareOrder = 1;

        public void AddMiddlewareInstaller(WebApplication app)
        {
            app.UseSerilogRequestLogging(config =>
            {
                config.MessageTemplate = "HTTP {RequestMethod} {requestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000}ms";
            });
        }
    }
}
