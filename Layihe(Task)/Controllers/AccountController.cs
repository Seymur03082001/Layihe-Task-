using Layihe_Task_.Models;
using Layihe_Task_.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Layihe_Task_.Controllers
{
    public class AccountController : Controller
    {
        UserManager<User> _userManager { get; }
        SignInManager<User> _signInManager { get; }
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register()=> View();

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            if (!ModelState.IsValid) ;

            User user = new User
            {
                FirstName = userRegisterVM.FirstName,
                LastName = userRegisterVM.LastName,
                UserName = userRegisterVM.UserName,
                Email = userRegisterVM.Email
            };
            IdentityResult result = await _userManager.CreateAsync(user,userRegisterVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors) ModelState.AddModelError("", item.Description);
                return View();
            }
            await _signInManager.SignInAsync(user, true);
            return RedirectToAction(nameof(Login),"Account");
        }
        [HttpGet]
        public async Task<IActionResult> Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if (!ModelState.IsValid) return View();
            User user = await _userManager.FindByNameAsync(userLoginVM.UserName);
            if (user == null) { ModelState.AddModelError("Username", "Username yoxdur"); return View(); }
            var result = await _signInManager.PasswordSignInAsync(user,userLoginVM.Password,userLoginVM.IsParsistance,true);
            if (!result.Succeeded) { ModelState.AddModelError("Username", "Username yoxdur"); return View(); }
            return RedirectToAction(nameof(Index), "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
