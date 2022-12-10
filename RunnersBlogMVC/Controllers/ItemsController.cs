using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services;
using System.Diagnostics.CodeAnalysis;

namespace RunnersBlogMVC.Controllers
{
    [ExcludeFromCodeCoverage]
    public class ItemsController : Controller
    {
        private readonly IBaseService<Item, ItemDto> itemService;
        private readonly CancellationToken cancellationToken;
        public ItemsController(IBaseService<Item, ItemDto> itemService)
        {
            this.itemService = itemService;
            cancellationToken = new CancellationToken();
        }
        // GET /items/createItem
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteItemAsync(Guid id)
        {
            return await itemService.MiddlePage(id, cancellationToken);
        }
        public async Task<IActionResult> UpdateItemAsync(Guid id)
        {
            return await itemService.MiddlePage(id, cancellationToken);
        }
        // GET /items/createItem
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateItem()
        {
            return View();
        }
        //GET /items/getAllItems
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllItemsAsync()
        {
            return await itemService.GetAllAsync(cancellationToken);

        }
        //POST /createItem/Item/{id}
        [HttpPost]
        [ValidateAntiForgeryToken] 
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateItemAsync(ItemDto itemDto)
        {
            return await itemService.CreateAsync(itemDto, cancellationToken);
        }
        //PUT /items/editItem/{id}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateByIdAsync(Guid id, ItemDto itemDto)
        {
            return await itemService.UpdateByIdAsync(id, itemDto, cancellationToken);
        }
        //DELETE /items/deleteItem/{id}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Item>> DeleteByIdAsync(Guid id)
        {
            return await itemService.DeleteByIdAsync(id, cancellationToken);
        }
    }
}

