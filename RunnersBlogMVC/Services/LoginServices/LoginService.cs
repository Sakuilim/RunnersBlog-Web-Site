using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.Services.LoginServices
{
    public class LoginService : Controller, ILoginService
    {

        private readonly UserManager<User> _userManager; 
        private readonly SignInManager<User> _signInManager;

        public LoginService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> LoginUser([Required] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User appUser = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (appUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(appUser.UserName, loginViewModel.Password, false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(nameof(loginViewModel.Email), "Login Failed: Invalid Email or Password");
            }
            return View("LoginUser");
        }
        public async Task<IActionResult> LogoutUser()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
