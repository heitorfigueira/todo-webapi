using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpPost]
        public IActionResult Create(CreateToDoList request)
        {
            return Ok(_todoListService.Create(request));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_todoListService.Delete(id));
        }

        [HttpPost]
        [Route("query")]
        public IActionResult List(ListToDoList request)
        {
            return Ok(_todoListService.List(request));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_todoListService.Get(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateToDoList request)
        {
            return Ok(_todoListService.Update(request));
        }
    }
}
