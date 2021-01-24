using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.API.Models
{
    public class MockToDoList : IToDoList
    {
        private readonly List<ToDoItem> toDos;
        public MockToDoList()
        {
            toDos = new List<ToDoItem>()
            {
                new ToDoItem()
                {
                    Id = Guid.NewGuid(),
                    Text = "Playing Football",
                    Completed = false
                },
                new ToDoItem()
                {
                    Id = Guid.NewGuid(),
                    Text = "C# Studying",
                    Completed = true
                },
                new ToDoItem()
                {
                    Id = Guid.NewGuid(),
                    Text = "Watching TV",
                    Completed = false
                }
            };
        }
        public ToDoItem AddItem(ToDoItem toDoItem)
        {
            toDoItem.Id = Guid.NewGuid();
            toDos.Add(toDoItem);

            return toDoItem;
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return toDos;
        }

        public ToDoItem GetItem(Guid id)
        {
            return toDos.FirstOrDefault(t => t.Id == id);
        }

        public ToDoItem UpdateItem(ToDoItem toDoItem)
        {
            var existingToDoItem = toDos.FirstOrDefault(kh => kh.Id == toDoItem.Id);
            existingToDoItem.Text = toDoItem.Text;
            existingToDoItem.Completed = toDoItem.Completed;

            return existingToDoItem;
        }
    }
}
