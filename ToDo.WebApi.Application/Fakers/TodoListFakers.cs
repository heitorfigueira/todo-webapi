using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.Fakers
{
    public static class TodoListFakers
    {
        public static TodoList GenerateSingleList()
        {
            return GenerateTodoList(1).First();
        }

        public static IEnumerable<TodoList> GenerateTodoList(int quantity)
        {
            return new Faker<TodoList>()
                            .CustomInstantiator(faker => new()
                            {
                                Id = faker.UniqueIndex,
                                Name = faker.Lorem.Lines(1),
                                Description = faker.Lorem.Lines(2)
                            })
                            .RuleFor(list => list.Items, 
                            (faker, list) => TodoItemFakers.GenerateTodoItem(list.Id, 3))
                            .Generate(quantity);
        }
    }
}
