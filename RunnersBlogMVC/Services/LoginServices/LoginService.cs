using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.Services.LoginServices
{
    public class LoginService : Controller, ILoginService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ActionResult> LoginUser([Required][EmailAddress] string email, [Required] string password)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = await _userManager.FindByEmailAsync(email);
                if (appUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(nameof(email), "Login Failed: Invalid Email or Password");

            }
            return View();
        }
        public async Task<ActionResult> LogoutUser()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
