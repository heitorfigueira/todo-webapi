using AutoMapper;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.Mappers
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<CreateTodoItem, TodoItem>();
        }
    }
}
