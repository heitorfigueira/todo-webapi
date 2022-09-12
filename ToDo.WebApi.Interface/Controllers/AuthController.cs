using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.Contracts.Services;
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
        public IActionResult Signin(Auth request)
        {
            return _authService.Signin(request)
                .Match(signin => Ok(signin), Problem);
        }

        [HttpPut]
        [Route("signoff")]
        public IActionResult Signoff()
        {
            return _authService.Signoff()
                .Match(_ => NoContent(), Problem);
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult Signup(Auth request)
        {
            return _authService.Signup(request)
                .Match(signup => Ok(signup), Problem);
        }
    }
}
