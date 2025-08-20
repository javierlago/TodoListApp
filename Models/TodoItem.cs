using System;
namespace TodoListApp.Models
{



    public class TodoItem
    {
        public int Id { get; set; } // Internal index
        public string Title { get; set; } // Task caption
        public bool IsDone { get; set; } // Task state
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Date of creation

    }

}