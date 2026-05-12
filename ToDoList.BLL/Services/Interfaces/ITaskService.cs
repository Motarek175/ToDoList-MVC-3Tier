using ToDoList.BLL.DTOs;

namespace ToDoList.BLL.Services.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<GetTaskDTO> GetAll();
        IEnumerable<GetTaskDTO> GetAll(string userId);
        GetTaskDTO GetById(int id);
        void Add(CreateTaskDTO dto);
        void Update(UpdateTaskDTO dto);
        void Delete(int id);

    }
}
