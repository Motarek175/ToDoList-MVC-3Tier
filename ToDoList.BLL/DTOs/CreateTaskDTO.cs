namespace ToDoList.BLL.DTOs
{
    public class CreateTaskDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string UserId { get; set; }
    }
}
