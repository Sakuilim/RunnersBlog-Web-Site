using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Controllers;
using DataAccessLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using DataAccessLayer.Repositories;
using System.Security.Claims;

namespace DataAccessLayer.Services.ItemsServices
{
    public class ItemsService : Controller, IItemsService
    {
        private readonly IItemsRepository repo;
        private readonly UserManager<ApplicationUser> userManager;
        public ItemsService(IItemsRepository repo, UserManager<ApplicationUser> userManager)
        {
            this.repo = repo;
            this.userManager = userManager;
        }

        public async Task<IActionResult> CreateAsync(string email, ItemDto itemDto, CancellationToken cancellationToken)
        {
            var currentUser = await userManager.FindByEmailAsync(email);
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedBy = currentUser.UserName
            };
            await repo.CreateItemAsync(item, cancellationToken);

            return RedirectToAction("GetAllItems", new RouteValueDictionary(new { Controller = "Items", Action = "GetAllItems" }));
        }

        public async Task<ActionResult<Item>> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var existingItem = await repo.GetItemAsync(id, cancellationToken);
            if (existingItem is null)
            {
                return NotFound();
            }

            await repo.DeleteItemAsync(id, cancellationToken);
            return RedirectToAction("GetAllItems", new RouteValueDictionary(new { Controller = "Items", Action = "GetAllItems" }));
        }

        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var items = await repo.GetItemsAsync(cancellationToken);

            ViewBag.Items = items ?? new List<Item>();
            return View("GetItems");
        }

        public async Task<ActionResult<Item>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await repo.GetItemAsync(id, cancellationToken);

            if (item is null)
            {
                return NotFound();
            }
            return View("Item");
        }

        public async Task<IActionResult> UpdateByIdAsync(Guid id, ItemDto itemDto, CancellationToken cancellationToken)
        {
            var existingItem = await repo.GetItemAsync(id, cancellationToken);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
                Description = itemDto.Description,
                ItemAvailabilityStatus = itemDto.ItemAvailabilityStatus.ToString()
            };

            await repo.UpdateItemAsync(updatedItem, cancellationToken);
            return RedirectToAction("GetAllItems", new RouteValueDictionary(new { Controller = "Items", Action = "GetAllItems" }));
        }
        public async Task<IActionResult> MiddlePage(Guid id, CancellationToken cancellationToken)
        {
            var item = await repo.GetItemAsync(id, cancellationToken);

            return View(item);
        }
        public async Task<IActionResult> GetOrderedItemsAsync(string orderedBy, CancellationToken cancellationToken)
        {
            var items = await repo.GetItemsAsync(cancellationToken);

            items = items.OrderBy(x => x.Price).ToList();

            ViewBag.Items = items;
            return View("GetItems");
        }
        public async Task<IActionResult> ReserveItemAsync(string email, Guid id, CancellationToken cancellationToken)
        {
            var currentUser = await userManager.FindByEmailAsync(email);

            var items = await repo.GetItemsAsync(cancellationToken);
            var existingItem = await repo.GetItemAsync(id, cancellationToken);

            existingItem.ItemAvailabilityStatus = ItemStatus.Reserved.ToString();
            existingItem.ReservedBy = currentUser.Id;

            Item updatedItem = existingItem with
            {
                ItemAvailabilityStatus = existingItem.ItemAvailabilityStatus,
                ReservedBy = currentUser.Id
            };

            await repo.UpdateItemAsync(updatedItem, cancellationToken);

            ViewBag.Items = items;

            return RedirectToAction("GetAllItems", new RouteValueDictionary(new { Controller = "Items", Action = "GetAllItems" }));
        }
        public async Task<IActionResult> ReservedItemsListAsync(string email, CancellationToken cancellationToken)
        {
            var items = await repo.GetItemsAsync(cancellationToken);

            var currentUser = await userManager.FindByEmailAsync(email);

            var filteredItems = items.Where(x => (x.ReservedBy == currentUser.Id && x.ItemAvailabilityStatus == ItemStatus.Reserved.ToString()));

            ViewBag.Items = filteredItems ?? new List<Item>();
            return View("ReservedItemsList");
        }
        public async Task<IActionResult> CancelReservedItemAsync(string email, Guid id, CancellationToken cancellationToken)
        {
            var currentUser = await userManager.FindByEmailAsync(email);

            var items = await repo.GetItemsAsync(cancellationToken);

            var filteredItems = items.Where(x => x.ReservedBy == currentUser.Id);

            var existingItem = await repo.GetItemAsync(id, cancellationToken);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                ItemAvailabilityStatus = ItemStatus.Available.ToString(),
                ReservedBy = Guid.Empty
            };

            await repo.UpdateItemAsync(updatedItem, cancellationToken);

            ViewBag.Items = filteredItems;

            return RedirectToAction("ReservedItemsList", new RouteValueDictionary(new { Controller = "Items", Action = "ReservedItemsList" }));
        }
        public async Task<IActionResult> BuyReservedItemAsync(string email, Guid id, CancellationToken cancellationToken)
        {
            var currentUser = await userManager.FindByEmailAsync(email);

            var items = await repo.GetItemsAsync(cancellationToken);

            var filteredItems = items.Where(x => x.ReservedBy == currentUser.Id);

            var existingItem = await repo.GetItemAsync(id, cancellationToken);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                ItemAvailabilityStatus = ItemStatus.Sold.ToString()
            };

            await repo.UpdateItemAsync(updatedItem, cancellationToken);

            ViewBag.Items = filteredItems;

            return RedirectToAction("ReservedItemsList", new RouteValueDictionary(new { Controller = "Items", Action = "ReservedItemsList" }));
        }
        public async Task<IActionResult> SearchItemAsync(string? searchBy, CancellationToken cancellationToken)
        {
            var items = await repo.GetItemsAsync(cancellationToken);

            var filtereditems = items.Where(x => x.Name.Contains(searchBy));

            ViewBag.Items = filtereditems;
            return View("GetItems");
        }
    }
}