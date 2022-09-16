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
        public IActionResult Create(CreateTodoList request)
        {
            return OkOrProblem(_todoListService.Create(request));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return OkOrProblem(_todoListService.Delete(id));
        }

        [HttpPost]
        [Route("query")]
        public IActionResult List(ListTodoList request)
        {
            return OkOrProblem(_todoListService.List(request));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return OkOrProblem(_todoListService.Get(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateTodoList request)
        {
            return OkOrProblem(_todoListService.Update(request));
        }
    }
}
