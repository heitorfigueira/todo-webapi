using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Domain.Entities;
using WebApi.Framework.Controllers;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ExtendedControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public IActionResult Signin(Auth request)
        {
            return OkOrProblem(_authService.Signin(request));
        }

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public IActionResult Signup(Auth request)
        {
            var user = HttpContext.Items["User"] as User;

            return OkOrProblem(_authService.Signup(request, user ?? null));
        }
    }
}
