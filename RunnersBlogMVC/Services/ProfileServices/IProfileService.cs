using Microsoft.AspNetCore.Mvc;

namespace RunnersBlogMVC.Services.ProfileServices
{
    public interface IProfileService
    {
        public Task<IActionResult> UserProfileAsync(string email, CancellationToken cancellationToken);
    }
}
