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
        private static Faker<TodoItem> _faker =
            new Faker<TodoItem>()
                .CustomInstantiator(faker => new()
                {
                    Id = faker.UniqueIndex,
                    Description = faker.Lorem.Paragraph(1),
                    Done = faker.Random.Number() % 2 == 0 ? true : false
                });

        public static Faker<TodoItem> InternalFaker()
        {
            return _faker;
        }

        public static TodoItem GenerateSingleItem(int todoListId)
        {
            return GenerateTodoItem(todoListId, 1).First();
        }

        public static ICollection<TodoItem> GenerateTodoItem(int todoListId, int quantity)
        {
            return _faker
                .RuleFor(item => item.TodoListId, todoListId)
                .Generate(quantity);
        }
    }
}
