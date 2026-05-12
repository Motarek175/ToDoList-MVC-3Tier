namespace ToDoList.BLL.DTOs
{
    public class GetUsersDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TasksCount { get; set; } = 0;
    }
}
