using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Services;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RunnersBlogMVC.Controllers
{
    [ExcludeFromCodeCoverage]
    public class UserController : Controller
    {
        private readonly IBaseService<User, User> userService;
        public UserController(IBaseService<User, User> userService)
        {
            this.userService = userService;
        }
        //Post : User/CreateUser
        [AllowAnonymous]
        [HttpPost]  
        public async Task<IActionResult> CreateUser(User user)
        {
            IActionResult result = user is null ? View() : await userService.CreateAsync(user, CancellationToken.None);
            return result;
        }
    }

}
