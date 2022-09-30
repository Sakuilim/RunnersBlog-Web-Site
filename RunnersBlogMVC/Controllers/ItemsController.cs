using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using System.Linq;

namespace RunnersBlogMVC.Controllers
{
    //[Authorize]
    public class ItemsController : Controller
    {
        private readonly IItemsRepository repo;
        public ItemsController(IItemsRepository repo)
        {
            this.repo = repo;
        }
        // GET /items/GetItems
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetItemsAsync()
        {
            var items = await repo.GetItemsAsync();

            ViewBag.Items = items;
            return View("GetItems");
        }
        // GET /items/CreateItem
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateItem()
        {
            return View();
        }
        //POST /CreateItem/Item/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };

            await repo.CreateItemAsync(item);
            return RedirectToAction("GetItems");
        }
        // GET Items/EditItem/{id}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Item>> EditItemAsync(Guid id)
        {
            var item = await repo.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return View(item);
        }
        //PUT Items/EditItem/{id}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditItemAsync(Guid id, Item itemDto)
        {
            var existingItem = await repo.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
            };

            await repo.UpdateItemAsync(updatedItem);
            return RedirectToAction("GetItems");
        }
        //DELETE Items/DeleteItem/{id}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Item>> DeleteItemAsync(Guid id)
        {
            var item = await repo.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return View(item);
        }
        //DELETE Items/DeleteItem/{id}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Item>> DeleteItemPOSTAsync(Guid id)
        {
            var existingItem = await repo.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            await repo.DeleteItemAsync(id);
            return RedirectToAction("GetItems");
        }
    }
}

