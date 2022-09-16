using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using WebApi.Framework.Controllers;

namespace ToDo.WebApi.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoItemController : ExtendedControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpPost]
        public IActionResult Create(CreateTodoItem request)
        {
            return OkOrProblem(_todoItemService.Create(request));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return OkOrProblem(_todoItemService.Delete(id));
        }

        [HttpPost]
        [Route("query")]
        public IActionResult List(ListTodoItem request)
        {
            return OkOrProblem(_todoItemService.List(request));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return OkOrProblem(_todoItemService.Get(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateTodoItem request)
        {
            return OkOrProblem(_todoItemService.Update(request));
        }
    }
}
