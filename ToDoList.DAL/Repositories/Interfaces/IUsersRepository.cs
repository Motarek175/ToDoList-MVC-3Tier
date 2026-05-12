using Microsoft.AspNetCore.Identity;

namespace ToDoList.DAL.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        public IEnumerable<IdentityUser> GetAll();

    }
}
