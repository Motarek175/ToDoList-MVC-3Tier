using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.PL.ViewModel.Auth;

namespace ToDoList.PL.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.Email,
                    PhoneNumber = registerVM.PhoneNumber,
                };
                var result = await _userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    var rolrReult = await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            ModelState.AddModelError("", "Please fill in all fields");
            return View(registerVM);

        }
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Please fill in all fields");
                return View(loginVM);
            }

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }

    }
}
