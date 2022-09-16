using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.Fakers
{
    public static class TodoItemFakers
    {
        public static TodoItem GenerateSingleItem(int todoListId)
        {
            return GenerateTodoItem(todoListId, 1).First();
        }

        public static ICollection<TodoItem> GenerateTodoItem(int todoListId, int quantity)
        {
            return new Faker<TodoItem>()
                           .CustomInstantiator(faker => new()
                           {
                               TodoListId = todoListId,
                               Id = faker.UniqueIndex,
                               Description = faker.Lorem.Paragraph(1),
                               Done = faker.Random.Number() % 2 == 0 ? true : false
                           }).Generate(quantity);
        }
    }
}
