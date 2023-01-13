using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Services.RoleServices
{
    public class RoleService : Controller, IRoleService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> CreateRole([Required][EmailAddress] string email, UserRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            User existingAppUser = await userManager.FindByEmailAsync(email);
            if (existingAppUser == null)
            {
                return View();
            }

            existingAppUser.Role = null;

            bool userRoleExists = await roleManager.RoleExistsAsync(userRole.ToString());
            if (!userRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = userRole.ToString() });
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

            return View();
        }
        public async Task<IActionResult> ShowAllRolesAsync()
        {
            var user = await userManager.GetUserAsync(User);
            var roles = await userManager.GetRolesAsync(user);

            ViewData["Roles"] = string.Join(", ", roles);

            return View();
        }
    }
}
