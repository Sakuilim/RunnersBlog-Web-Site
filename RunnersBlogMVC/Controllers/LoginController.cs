﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using RunnersBlogMVC.Services.LoginServices;

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
        public async Task<IActionResult> LoginUser([Required] LoginViewModel loginViewModel)
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
