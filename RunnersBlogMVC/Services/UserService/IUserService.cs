using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;

namespace DataAccessLayer.Services.UserService
{
    public interface IUserService
    {
        public Task<IActionResult> CreateAsync(User user, CancellationToken cancellationToken);
    }
}