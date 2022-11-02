using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Controllers;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;

namespace RunnersBlogMVC.Services
{
    public class ItemsService : Controller, IBaseService<Item,CreateItemDto>
    {
        private readonly IItemsRepository repo;
        public ItemsService(IItemsRepository repo)
        {
            this.repo = repo;
        }

        public async Task<ActionResult> CreateAsync(CreateItemDto itemDto, CancellationToken cancellationToken)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
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
            return RedirectToAction("GetAllItems", new RouteValueDictionary ( new { Controller = "Items", Action = "GetAllItems" } ));
        }

        public async Task<ActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var items = await repo.GetItemsAsync(cancellationToken);

            ViewBag.Items = items;
            return View("GetItems");
        }

        public async Task<ActionResult<Item>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await repo.GetItemAsync(id, cancellationToken);

            if(item is null)
            {
                return NotFound();
            }
            return View("Item");
        }

        public async Task<ActionResult> UpdateAsync(Guid id, CreateItemDto item, CancellationToken cancellationToken)
        {
            var existingItem = await repo.GetItemAsync(id, cancellationToken);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = item.Name,
                Price = item.Price,
            };

            await repo.UpdateItemAsync(updatedItem, cancellationToken);
            return RedirectToAction("GetItems");
        }
        public async Task<ActionResult> DeleteMiddlePage(Guid id, CancellationToken cancellationToken)
        {
            var item = await repo.GetItemAsync(id, cancellationToken);

            return View(item);
        }
    }
}
