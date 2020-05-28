using System.Threading.Tasks;
using BLL.Abstract;
using BLL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public AccountController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
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
            if (!ModelState.IsValid) return View(model);

            var userIdentityResult = await _userService.Register(model);

            if (!userIdentityResult.Result.Succeeded)
            {
                foreach (var error in userIdentityResult.Result.Errors) ModelState.TryAddModelError(error.Code, error.Description);

                return View(model);
            }

            await _userService.Login(new UserLoginModel
            {
                Email = model.Email, Password = model.Password, RememberMe = true
            });
            var code = await _emailService.GenerateEmailConfirmationTokenAsync(userIdentityResult.User);
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new {code},
                HttpContext.Request.Scheme);
            await _emailService.SendEmailAsync(model.Email, "Confirm your account",
                $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>confirm email</a>");

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private async Task<User> GetCurrentUser()
        {
            return await _userService.GetUserByClaims(HttpContext.User);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string code)
        {
            if (code == null) return View("Error");

            var user = await GetCurrentUser();
            if (user == null) return View("Error");
            var result = await _userService.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            return View("Error");
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
            if (!ModelState.IsValid) return View(model);

            var result = await _userService.Login(model);

            if (result.Succeeded) return RedirectToLocal(returnUrl);

            ModelState.AddModelError("", "Invalid email or password.");
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);

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