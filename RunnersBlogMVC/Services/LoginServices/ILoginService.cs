using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.Services.LoginServices
{
    public interface ILoginService
    {
        public Task<IActionResult> LoginUser([Required] LoginViewModel loginViewModel);
        public Task<IActionResult> LogoutUser();
    }
}
