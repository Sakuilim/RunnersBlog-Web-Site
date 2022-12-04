using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Services.LoginServices;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService accountService;
        public LoginController(ILoginService accountService)
        {
            this.accountService = accountService;
        }
        public IActionResult Login()
        {
            return View();
        }
        //POST /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Required][EmailAddress] string email, [Required] string password)
        {
            return await accountService.LoginUser(email, password);
        }
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            return await accountService.LogoutUser();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
