using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using RunnersBlogMVC.Services.ProfileServices;

namespace DataAccessLayer.Controllers
{
    [ExcludeFromCodeCoverage]
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        private readonly CancellationToken cancellationToken;
        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
            cancellationToken= new CancellationToken();
        }
        public IActionResult UserProfile()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UserProfileAsync()
        {
            var email = HttpContext.User.Claims.Where(c => c.Type.Contains("emailaddress"))?.FirstOrDefault()?.Value;
            if(email is null)
            {
                return RedirectToAction("LoginUser", new RouteValueDictionary(new { Controller = "Login", Action = "LoginUser" }));
            }
            return await profileService.UserProfileAsync(email, cancellationToken);
        }
    }
}
