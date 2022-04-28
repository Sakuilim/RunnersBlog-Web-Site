using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using System.Linq;

namespace RunnersBlogMVC.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsRepository repo;
        public ItemsController(IItemsRepository repo)
        {
            this.repo = repo;
        }
        // GET /items
        [HttpGet]
        public async Task<ActionResult> GetItemsAsync()
        {
            var items = (await repo.GetItemsAsync())
                        .Select(item => item.AsDto());
            ViewBag.Items = items;
            // return items;
            return View();
        }
        // GET /items/{id}
        [HttpGet]
        public async Task<ActionResult<ItemDto>> EditItemAsync(Guid id)
        {
            var item = await repo.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return View(item.AsDto());
        }
        //POST /items
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            //return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
            //  return View();
            return RedirectToAction("GetItems");
        }
        //PUT /items/{id}
        [HttpPost]
        public async Task<ActionResult> EditItemAsync(Guid id, ItemDto itemDto)
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
            // return NoContent();
            // return View(updatedItem);
            return RedirectToAction("GetItems");
        }
        [HttpGet]
        public async Task<ActionResult<ItemDto>> DeleteItemAsync(Guid id)
        {
            var item = await repo.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return View(item.AsDto());
        }
        //Delete /items/{id}
        [HttpPost]
        public async Task<ActionResult> DeleteItemPOSTAsync(Guid id)
        {
            var existingItem = await repo.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            await repo.DeleteItemAsync(id);

            return RedirectToAction("GetItems");
        }
        [HttpGet]
        public ActionResult CreateItem()
        {
            return View();
        }
    }
}
