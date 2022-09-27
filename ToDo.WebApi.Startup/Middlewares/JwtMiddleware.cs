using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Services;
using WebApi.Framework.Installers;
using WebApi.Framework.Middlewares;

namespace ToDo.WebApi.Startup.Middlewares
{
    public class JwtMiddleware : AbstractMiddleware
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public JwtMiddleware(RequestDelegate next, IUserService userService, IJwtService jwtService) : base(next)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        public override async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request
                            .Headers["Authorization"]
                            .FirstOrDefault()?.Split(" ")
                            .Last();

            var userId = _jwtService.ValidateToken(token);

            if (!userId.IsError)
            {
                var userResponse = _userService.Get(userId.Value);

                if (!userResponse.IsError)
                    context.Items["User"] = userResponse.Value;
            }

            await _next(context);
        }
    }
}
