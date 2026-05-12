using Microsoft.AspNetCore.Identity;
using ToDoList.DAL.Repositories.Interfaces;

namespace ToDoList.DAL.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IEnumerable<IdentityUser> GetAll()
        {
            return _userManager.GetUsersInRoleAsync("User").Result;
        }
    }
}
