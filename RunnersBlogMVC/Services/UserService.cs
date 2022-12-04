using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;

namespace RunnersBlogMVC.Services
{
    public class UserService : Controller, IBaseService<User, User>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<ActionResult> CreateAsync(User user, CancellationToken cancellationToken)
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
                if (!userRoleExists)
                {
                    await roleManager.CreateAsync(new ApplicationRole() { Name = "User" });
                }

                await userManager.AddToRoleAsync(appUser, UserRole.User.ToString());

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
        public Task<ActionResult<User>> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<ActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<ActionResult<User>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<ActionResult> UpdateByIdAsync(Guid id, User dataToUpdateWith, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<ActionResult> MiddlePage(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
