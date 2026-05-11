using ToDoList.BLL.DTOs;
using ToDoList.BLL.Services.Interfaces;
using ToDoList.DAL.Entity;
using ToDoList.DAL.Repositories.Interfaces;

namespace ToDoList.BLL.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        void ITaskService.Add(CreateTaskDTO task)
        {
            var AddedTask = new TDLTask
            {
                Title = task.Title,
                Description = task.Description,
                IsCompleted = false,
                UserId = task.UserId
            };
            _taskRepository.Add(AddedTask);
        }

        void ITaskService.Delete(int id)
        {
            _taskRepository.Delete(id);
        }

        IEnumerable<GetTaskDTO> ITaskService.GetAll(string userId)
        {
            var tasks = _taskRepository.GetAll(userId);
            return tasks.Select(t => new GetTaskDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
            });
        }

        GetTaskDTO ITaskService.GetById(int id)
        {
            var task = _taskRepository.GetById(id);
            if (task == null)
                return null;

            return new GetTaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
            };
        }

        void ITaskService.Update(UpdateTaskDTO task)
        {
            var updatedTask = _taskRepository.GetById(task.Id);
            if (updatedTask != null)
            {
                updatedTask.IsCompleted = task.IsCompleted;
                _taskRepository.Update(updatedTask);
            }
        }
    }
}
