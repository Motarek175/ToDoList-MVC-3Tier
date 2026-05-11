using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.PL.ViewModel.Auth;

namespace ToDoList.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleVM model)
        {
            var roleExist = await _roleManager.RoleExistsAsync(model.Name);
            if (!roleExist)
            {
                var role = new IdentityRole(model.Name);
                var result = await _roleManager.CreateAsync(role);
            }
            return View(model);

        }
    }
}
