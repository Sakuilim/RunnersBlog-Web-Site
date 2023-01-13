using Microsoft.AspNetCore.Mvc;

namespace DataAccessLayer.Services.ProfileServices
{
    public interface IProfileService
    {
        public Task<IActionResult> UserProfileAsync(string email, CancellationToken cancellationToken);
    }
}
