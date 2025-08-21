using System;
using System.ComponentModel.DataAnnotations;
namespace TodoListApp.Models
{



    public class TodoItem
    {
        
        public int Id { get; set; } // Internal index
        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;// Task caption
        public bool IsDone { get; set; } // Task state
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Date of creation

    }

}