using ToDoList.BLL.DTOs;

namespace ToDoList.BLL.Services.Interfaces
{
    public interface IUsersService
    {
        public IEnumerable<GetUsersDTO> GetAll();
    }
}
