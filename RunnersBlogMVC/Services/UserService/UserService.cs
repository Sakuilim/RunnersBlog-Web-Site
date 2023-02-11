using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.Diagnostics.CodeAnalysis;
using DataAccessLayer.DTO;
using DataAccessLayer.Models.Items;

namespace RunnersBlogMVC.Services.UserService
{
    public class UserService : Controller, IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                user.UserName = user.Name;

                var checkIfUserExists = await userManager.FindByEmailAsync(user.Email);

                if (checkIfUserExists != null)
                {
                    ModelState.AddModelError("Error", errorMessage: "This email already exists");
                }


                IdentityResult result = await userManager.CreateAsync(user, user.Password);

                user.SecurityStamp = Guid.NewGuid().ToString();

                bool userRoleExists = await roleManager.RoleExistsAsync("User");
                if (!userRoleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole() { Name = "User" });
                }

                await userManager.AddToRoleAsync(user, UserRole.User.ToString());

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
                ModelState.AddModelError("Error", errorMessage: "There was an error in user creation");
            }
            return View(user);
        }
        [ExcludeFromCodeCoverage]
        public Task<ActionResult<User>> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        [ExcludeFromCodeCoverage]
        public Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        [ExcludeFromCodeCoverage]
        public Task<ActionResult<User>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        [ExcludeFromCodeCoverage]
        public Task<IActionResult> UpdateByIdAsync(Guid id, User dataToUpdateWith, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        [ExcludeFromCodeCoverage]
        public Task<IActionResult> MiddlePage(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
