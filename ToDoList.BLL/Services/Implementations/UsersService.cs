using ToDoList.BLL.DTOs;
using ToDoList.BLL.Services.Interfaces;
using ToDoList.DAL.Repositories.Interfaces;

namespace ToDoList.BLL.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITaskRepository _taskRepository;
        public UsersService(IUsersRepository usersRepository, ITaskRepository taskRepository)
        {
            _usersRepository = usersRepository;
            _taskRepository = taskRepository;
        }

        public IEnumerable<GetUsersDTO> GetAll()
        {
            var users = _usersRepository.GetAll();
            return users.Select(u => new GetUsersDTO
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                TasksCount = _taskRepository.GetAll(u.Id).Count()
            });
        }
    }
}
