using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using RunnersBlogMVC.Services.UserService;

namespace DataAccessLayer.Controllers
{
    [ExcludeFromCodeCoverage]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
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
            return await userService.CreateAsync(user, CancellationToken.None);
        }
    }

}
