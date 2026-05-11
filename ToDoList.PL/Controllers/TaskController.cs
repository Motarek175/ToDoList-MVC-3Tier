using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL.DTOs;
using ToDoList.BLL.Services.Interfaces;
using ToDoList.PL.ViewModel;

namespace ToDoList.PL.Controllers
{
    [Authorize(Roles = "User")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<IdentityUser> _userManager;
        public TaskController(ITaskService taskService, UserManager<IdentityUser> userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var tasksDto = _taskService.GetAll(userId);
            var tasksVM = tasksDto.Select(t => new GetTaskVM
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted
            });
            return View(tasksVM);
        }
        public IActionResult MarkAsComplete(int id)
        {
            UpdateTaskVM vm = new UpdateTaskVM()
            {
                Id = id,
                IsCompleted = true
            };

            UpdateTaskDTO dto = new UpdateTaskDTO()
            {
                Id = vm.Id,
                IsCompleted = vm.IsCompleted
            };

            _taskService.Update(dto);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateTaskVM vm)
        {
            var userId = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                CreateTaskDTO dto = new CreateTaskDTO()
                {
                    Title = vm.Title,
                    Description = vm.Description,
                    UserId = userId
                };

                _taskService.Add(dto);

                return RedirectToAction("Index");
            }

            return View(vm);
        }

    }
}
