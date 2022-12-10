using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Services.LoginServices;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RunnersBlogMVC.Controllers
{
    [ExcludeFromCodeCoverage]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        public IActionResult LoginUser()
        {
            return View();
        }
        //POST /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(LoginViewModel loginViewModel)
        {
            return await loginService.LoginUser(loginViewModel);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            return await loginService.LogoutUser();
        }
    }
}
