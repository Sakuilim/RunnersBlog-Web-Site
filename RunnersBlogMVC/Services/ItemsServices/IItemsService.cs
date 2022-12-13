using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;

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
        public Task<IActionResult> CancelReservedItem(string email, Guid id, CancellationToken cancellationToken);
        public Task<IActionResult> BuyReservedItem(string email, Guid id, CancellationToken cancellationToken);
    }
}
