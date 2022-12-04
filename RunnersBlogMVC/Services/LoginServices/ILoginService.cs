using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.Services.LoginServices
{
    public interface ILoginService
    {
        public Task<ActionResult> LoginUser([Required][EmailAddress] string email,
            [Required] string password);
        public Task<ActionResult> LogoutUser();
    }
}
