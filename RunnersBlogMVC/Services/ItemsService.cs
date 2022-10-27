using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Controllers;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;

namespace RunnersBlogMVC.Services
{
    public class ItemsService : BaseController
    {
        private readonly IItemsRepository repo;
        public ItemsService(IItemsRepository repo)
        {
            this.repo = repo;
        }
        public async Task<ActionResult> CreateAsync(CreateItemDto data, CancellationToken cancellationToken)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = data.Name,
                Price = data.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };

            await repo.CreateItemAsync(item);
            return RedirectToAction("GetItems");
        }

        public async Task<ActionResult<Item>> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await repo.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return View(item);
        }

        public async Task<ActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var items = await repo.GetItemsAsync();

            ViewBag.Items = items;

            return View("GetItems");
        }

        public async Task<Item> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> UpdateAsync(Guid id, Item data, CancellationToken cancellationToken)
        {
            var existingItem = await repo.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = data.Name,
                Price = data.Price,
            };

            await repo.UpdateItemAsync(updatedItem);
            return RedirectToAction("GetItems");
        }
    }
}
