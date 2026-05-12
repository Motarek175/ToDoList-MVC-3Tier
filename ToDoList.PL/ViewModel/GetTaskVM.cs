namespace ToDoList.PL.ViewModel
{
    public class GetTaskVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public string UserName { get; set; }
    }
}
