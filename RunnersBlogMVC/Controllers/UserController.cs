using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.Controllers
{
    //Comment for code review
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult CreateUser()
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
                ApplicationUser appUser = new()
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

                appUser.SecurityStamp = Guid.NewGuid().ToString();

                bool userRoleExists = await roleManager.RoleExistsAsync("User");
                if(!userRoleExists)
                {
                    await roleManager.CreateAsync(new ApplicationRole() { Name = "User"});
                }

                await userManager.AddToRoleAsync(appUser,UserRole.User.ToString());

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
                ModelState.AddModelError("Error",errorMessage: "There was an error in user creation");
            }
            return View(user);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        //Post: User/CreateRole
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole([Required][EmailAddress] string email, UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser existingAppUser = await userManager.FindByEmailAsync(email);
                if (existingAppUser is not null)
                {
                    existingAppUser.Roles.Clear();

                    bool userRoleExists = await roleManager.RoleExistsAsync(userRole.ToString());
                    if (!userRoleExists)
                    {
                        await roleManager.CreateAsync(new ApplicationRole() { Name = userRole.ToString() });
                    }

                    var result = await userManager.AddToRoleAsync(existingAppUser, userRole.ToString());

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
