using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.API.Models
{
    public interface IToDoList
    {
        IEnumerable<ToDoItem> GetAll();
        ToDoItem AddItem(ToDoItem toDoItem);
        ToDoItem UpdateItem(ToDoItem toDoItem);
        ToDoItem GetItem(Guid id);
    }
}
