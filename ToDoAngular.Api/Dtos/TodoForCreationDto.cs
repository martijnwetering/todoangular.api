using System.ComponentModel.DataAnnotations;

namespace ToDoAngular.Api.Dtos
{
    public class TodoForCreationDto
    {
        [Required]
        public string Title { get; set; }
        public bool Completed = false;
    }
}