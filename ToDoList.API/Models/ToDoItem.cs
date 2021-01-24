using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.API.Models
{
    public class ToDoItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Text { get; set; }

        [Required]
        [MaxLength(5)]
        public bool Completed { get; set; } = false;
    }
}
