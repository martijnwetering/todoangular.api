using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoAngular.Api.Models
{
    public class Todo
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}