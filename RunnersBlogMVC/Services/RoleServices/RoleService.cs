using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Services.RoleServices
{
    public class RoleService : Controller, IRoleService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        public RoleService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
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

            ApplicationUser existingAppUser = await userManager.FindByEmailAsync(email);
            if (existingAppUser == null)
            {
                return View();
            }

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
