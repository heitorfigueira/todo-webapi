using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public IActionResult Create(CreateToDoItem request)
        {
            return Ok(_todoItemService.Create(request));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_todoItemService.Delete(id));
        }

        [HttpPost]
        [Route("query")]
        public IActionResult List(ListToDoItem request)
        {
            return Ok(_todoItemService.List(request));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_todoItemService.Get(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateToDoItem request)
        {
            return Ok(_todoItemService.Update(request));
        }
    }
}
