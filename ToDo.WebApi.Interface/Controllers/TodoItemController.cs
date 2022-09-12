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

        [HttpGet]
        public IActionResult Create(CreateToDoItem request)
        {
            return _todoItemService.Create(request)
                .Match(create => Ok(create), Problem);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return _todoItemService.Delete(id)
                .Match(delete => Ok(delete), Problem);
        }

        [HttpPost]
        [Route("query")]
        public IActionResult List(ListToDoItem request)
        {
            return _todoItemService.List(request)
                .Match(list => Ok(list), Problem);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return _todoItemService.Get(id)
                .Match(get => Ok(get), Problem);
        }

        [HttpPut]
        public IActionResult Update(UpdateToDoItem request)
        {
            return _todoItemService.Update(request)
                .Match(update => Ok(update), Problem);
        }
    }
}
