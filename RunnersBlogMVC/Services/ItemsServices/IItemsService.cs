using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.DTO;
using DataAccessLayer.Models.Items;

namespace RunnersBlogMVC.Services.ItemsServices
{
    public interface IItemsService
    {
        public Task<IActionResult> CreateAsync(string email, ItemDto itemDto, CancellationToken cancellationToken);
        public Task<ActionResult<Item>> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<IActionResult> GetAllAsync(CancellationToken cancellationToken);
        public Task<ActionResult<Item>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<IActionResult> UpdateByIdAsync(Guid id, ItemDto itemDto, CancellationToken cancellationToken);
        public Task<IActionResult> MiddlePage(Guid id, CancellationToken cancellationToken);
        public Task<IActionResult> GetOrderedItemsAsync(string orderedBy, CancellationToken cancellationToken);
        public Task<IActionResult> ReserveItemAsync(string email, Guid id, CancellationToken cancellationToken);
        public Task<IActionResult> ReservedItemsListAsync(string email, CancellationToken cancellationToken);
        public Task<IActionResult> CancelReservedItemAsync(string email, Guid id, CancellationToken cancellationToken);
        public Task<IActionResult> BuyReservedItemAsync(string email, Guid id, CancellationToken cancellationToken);
        public Task<IActionResult> SearchItemAsync(string searchBy, CancellationToken cancellationToken);
    }
}
