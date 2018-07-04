namespace ToDoAngular.Api.Dtos
{
    public class TodoForUpdateDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}