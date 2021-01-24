using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.API.Models
{
    public class SqlToDoData : IToDoList
    {
        private readonly ToDoContext _context;

        public SqlToDoData(ToDoContext context)
        {
            _context = context;
        }

        public ToDoItem AddItem(ToDoItem toDoItem)
        {
            toDoItem.Id = Guid.NewGuid();
            _context.ToDoItems.Add(toDoItem);
            _context.SaveChanges();

            return toDoItem;
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _context.ToDoItems.ToList();
        }

        public ToDoItem GetItem(Guid id)
        {
            return _context.ToDoItems.SingleOrDefault(r => r.Id == id);
        }

        public ToDoItem UpdateItem(ToDoItem toDoItem)
        {
            var toDo = _context.ToDoItems.Find(toDoItem.Id);
            if (toDo != null)
            {
                toDo.Text = toDoItem.Text;
                toDo.Completed = toDoItem.Completed;
                _context.SaveChanges();
            }

            return toDo;
        }
    }
}
