using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services;

namespace RunnersBlogMVC.Controllers
{
    //[Authorize]
    public class ItemsController : BaseController
    {
        private readonly IBaseService<Item,CreateItemDto> itemService;
        private readonly CancellationToken cancellationToken;
        public ItemsController(IBaseService<Item,CreateItemDto> itemService)
        {
            this.itemService = itemService;
            cancellationToken = new CancellationToken();
        }
        // GET /items/createItem
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Item>> DeleteItemAsync(Guid id)
        {
            return await itemService.DeleteMiddlePage(id, cancellationToken);
        }
        // GET /items/createItem
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateItem()
        {
            return View();
        }
        //GET /items/getAllItems
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllItemsAsync()
        {
            return await itemService.GetAllAsync(cancellationToken);

        }
        //POST /createItem/Item/{id}
        [HttpPost]
        [ValidateAntiForgeryToken] 
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateItemAsync(CreateItemDto itemDto)
        {
            return await itemService.CreateAsync(itemDto, cancellationToken);
        }
        //PUT /items/editItem/{id}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditItemAsync(Guid id, CreateItemDto currentItem)
        {
            return await itemService.UpdateAsync(id, currentItem, cancellationToken);
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

