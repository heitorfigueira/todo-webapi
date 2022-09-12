using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public IActionResult Create(CreateAccount request)
        {
            return _accountService.Create(request)
                        .Match(create => Ok(create), Problem);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            return _accountService.Delete(id)
                        .Match(delete => Ok(delete), Problem);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return _accountService.Get(id)
                        .Match(get => Ok(get), Problem);
        }

        [HttpPut]
        public IActionResult Update(UpdateAccount request)
        {
            return _accountService.Update(request)
                        .Match(update => Ok(update), Problem);
        }
    }
}
