﻿using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager; 
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        //Post : User/CreateUser
        [AllowAnonymous]
        [HttpPost]  
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

                appUser.SecurityStamp = Guid.NewGuid().ToString();

                bool userRoleExists = await _roleManager.RoleExistsAsync("User");
                if(!userRoleExists)
                {
                    await _roleManager.CreateAsync(new ApplicationRole() { Name = "User"});
                }

                await _userManager.AddToRoleAsync(appUser,UserRole.User.ToString());

                if (result.Succeeded)
                {
                    ViewBag.Message = "User Created Successfully"; 
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("Error",errorMessage: "wot");
            }
            return View(user);
        }
        //Post: User/CreateRole
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole([Required][EmailAddress] string email, UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser existingAppUser = await _userManager.FindByEmailAsync(email);
                if (existingAppUser is not null)
                {
                    existingAppUser.Roles.Clear();

                    bool userRoleExists = await _roleManager.RoleExistsAsync(userRole.ToString());
                    if (!userRoleExists)
                    {
                        await _roleManager.CreateAsync(new ApplicationRole() { Name = userRole.ToString() });
                    }

                    var result = await _userManager.AddToRoleAsync(existingAppUser, userRole.ToString());

                    if (result.Succeeded)
                    {
                        ViewBag.Message = result;
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            return View();
        }
    }

}
