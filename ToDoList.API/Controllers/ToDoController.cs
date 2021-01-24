using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.API.Models;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoList _context;

        public ToDoController(IToDoList context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllToDos()
        {
            return Ok(_context.GetAll());
        }

        [HttpPost]
        public IActionResult AddToDo(ToDoItem toDo)
        {
            var addToDo = _context.AddItem(toDo);
            if (addToDo == null) return BadRequest();

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + toDo.Id,
                addToDo);
        }

        [HttpPatch("{id}")]
        public IActionResult EditToDo(Guid id,ToDoItem toDoItem) //It doesn't work
        {
            var toDo = _context.GetItem(id);
            if (toDo == null) return NotFound();

            toDoItem.Id = toDo.Id;
            _context.UpdateItem(toDoItem);

            return Ok(toDoItem);
        }

        //Api Completed ?
    }
}
