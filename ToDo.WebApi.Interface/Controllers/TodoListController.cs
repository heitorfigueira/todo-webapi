using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using WebApi.Framework.Controllers;

namespace ToDo.WebApi.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoListController : ExtendedControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpPost]
        public IActionResult Create(CreateToDoList request)
        {
            return _todoListService.Create(request)
                       .Match(create => Ok(create), Problem);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return _todoListService.Delete(id)
                .Match(delete => Ok(delete), Problem);
        }

        [HttpPost]
        [Route("query")]
        public IActionResult List(ListToDoList request)
        {
            return _todoListService.List(request)
                .Match(list => Ok(list), Problem);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return _todoListService.Get(id)
                .Match(get => Ok(get), Problem);
        }

        [HttpPut]
        public IActionResult Update(UpdateToDoList request)
        {
            return _todoListService.Update(request)
                .Match(update => Ok(update), Problem);
        }
    }
}
