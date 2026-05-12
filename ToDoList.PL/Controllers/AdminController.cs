using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL.Services.Interfaces;
using ToDoList.PL.ViewModel;
using ToDoList.PL.ViewModel.Admin;

namespace ToDoList.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly ITaskService _taskService;
        public AdminController(IUsersService usersService, ITaskService taskService)
        {
            _usersService = usersService;
            _taskService = taskService;
        }
        public IActionResult Users()
        {
            var usersDto = _usersService.GetAll();
            var users = usersDto.Select(u => new GetUsersVM
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                TasksCount = u.TasksCount
            });
            return View(users);
        }

        public IActionResult Tasks()
        {
            var tasksDto = _taskService.GetAll();
            var tasks = tasksDto.Select(t => new GetTaskVM
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                UserName = t.UserName
            });
            return View(tasks);
        }

        public IActionResult DeleteTask(int id)
        {
            _taskService.Delete(id);
            return RedirectToAction("Tasks");
        }
    }
}
