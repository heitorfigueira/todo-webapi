using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.Contracts.Services;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
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
            return Ok(_authService.Signin(request));
        }

        [HttpPut]
        [Route("signoff")]
        public IActionResult Signoff()
        {
            _authService.Signoff();
            return NoContent();
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult Signup(Auth request)
        {
            _authService.Signup(request);
            return Ok();
        }
    }
}
