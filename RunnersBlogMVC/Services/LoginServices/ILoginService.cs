using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Services.LoginServices
{
    public interface ILoginService
    {
        public Task<IActionResult> LoginUser([Required] LoginViewModel loginViewModel);
        public Task<IActionResult> LogoutUser();
    }
}
