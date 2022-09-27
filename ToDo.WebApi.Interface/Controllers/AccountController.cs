using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using WebApi.Framework.Controllers;

namespace ToDo.WebApi.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ExtendedControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Create(CreateAccount request)
        {
            return OkOrProblem(_accountService.Create(request));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            return OkOrProblem(_accountService.Delete(id));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return OkOrProblem(_accountService.Get(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateAccount request)
        {
            return OkOrProblem(_accountService.Update(request));
        }
    }
}
