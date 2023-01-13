using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.DTO;
using DataAccessLayer.Services.ItemsServices;
using System.Diagnostics.CodeAnalysis;
using DataAccessLayer.Models.Items;

namespace DataAccessLayer.Controllers
{
    [ExcludeFromCodeCoverage]
    public class ItemsController : Controller
    {
        private readonly IItemsService itemService;
        private readonly CancellationToken cancellationToken;
        public ItemsController(IItemsService itemService)
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
        [Authorize(Roles = "Admin,User")]
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
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> CreateItemAsync(ItemDto itemDto)
        {
            var email = HttpContext.User.Claims.Where(c => c.Type.Contains("emailaddress"))?.FirstOrDefault()?.Value;
            if (email is null)
            {
                return RedirectToAction("LoginUser", new RouteValueDictionary(new { Controller = "Login", Action = "LoginUser" }));
            }
            return await itemService.CreateAsync(email, itemDto, cancellationToken);
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
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> OrderItemsAsync(string sortOrder)
        {
            return await itemService.GetOrderedItemsAsync(sortOrder, cancellationToken);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ReserveItemAsync(Guid id)
        {
            var email = HttpContext.User.Claims.Where(c => c.Type.Contains("emailaddress"))?.FirstOrDefault()?.Value;
            if (email is null)
            {
                return RedirectToAction("LoginUser", new RouteValueDictionary(new { Controller = "Login", Action = "LoginUser" }));
            }
            return await itemService.ReserveItemAsync(email, id, cancellationToken);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ReservedItemsListAsync()
        {
            var email = HttpContext.User.Claims.Where(c => c.Type.Contains("emailaddress"))?.FirstOrDefault()?.Value;
            if (email is null)
            {
                return RedirectToAction("LoginUser", new RouteValueDictionary(new { Controller = "Login", Action = "LoginUser" }));
            }
            return await itemService.ReservedItemsListAsync(email, cancellationToken);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CancelReservedItemAsync(Guid id)
        {
            var email = HttpContext.User.Claims.Where(c => c.Type.Contains("emailaddress"))?.FirstOrDefault()?.Value;
            if (email is null)
            {
                return RedirectToAction("LoginUser", new RouteValueDictionary(new { Controller = "Login", Action = "LoginUser" }));
            }
            return await itemService.CancelReservedItemAsync(email, id, cancellationToken);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> BuyReservedItemAsync(Guid id)
        {
            var email = HttpContext.User.Claims.Where(c => c.Type.Contains("emailaddress"))?.FirstOrDefault()?.Value;
            if (email is null)
            {
                return RedirectToAction("LoginUser", new RouteValueDictionary(new { Controller = "Login", Action = "LoginUser" }));
            }
            return await itemService.BuyReservedItemAsync(email, id, cancellationToken);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> SearchItemAsync(string searchBy)
        {
            return await itemService.SearchItemAsync(searchBy, cancellationToken);
        }
    }
}

