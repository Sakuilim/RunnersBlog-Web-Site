using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;

namespace RunnersBlogMVC.Services.UserService
{
    public interface IUserService
    {
        public Task<IActionResult> CreateAsync(User user, CancellationToken cancellationToken);
    }
}