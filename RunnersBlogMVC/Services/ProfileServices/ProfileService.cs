using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.Services.ProfileServices
{
    public class ProfileService : Controller, IProfileService
    {
        private readonly IItemsRepository repo;
        private readonly UserManager<ApplicationUser> userManager;
        public ProfileService(IItemsRepository repo, UserManager<ApplicationUser> userManager)
        {
            this.repo = repo;
            this.userManager = userManager;
        }
        public async Task<IActionResult> UserProfileAsync(string email, CancellationToken cancellationToken)
        {
            var items = await repo.GetItemsAsync(cancellationToken);

            var currentUser = await userManager.FindByEmailAsync(email);

            var filteredItems = items.Where(x => x.ReservedBy == currentUser.Id);

            filteredItems = filteredItems.Where(x => x.ItemAvailabilityStatus == ItemStatus.Sold.ToString());

            ViewBag.Items = filteredItems ?? new List<Item>();
            return View("UserProfile");
        }
    }
}
