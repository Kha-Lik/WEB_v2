using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
        
            var result =  await _userService.Register(model);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
            
                return View(model);
            }
        
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.Login(model);
        
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View();
            }
        }
    
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
        
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await _userService.SignOut();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}