using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using System.Linq;

namespace RunnersBlogMVC.Controllers
{
    [ApiController]
    [Route("/items")]
    public class ItemsController : Controller
    {
        private readonly IInMemItemsRepository repo;
        public ItemsController(IInMemItemsRepository repo)
        {
            this.repo = repo;
        }
        // GET /items
        [HttpGet]
        //public IActionResult GetItems()
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repo.GetItems().Select(item => item.AsDto());
            ViewBag.Items = items;
            return items;
            // return View();
        }
        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repo.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
        //POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };

            repo.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }
        //PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repo.GetItem(id);
            if(existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            { 
                Name = itemDto.Name,
                Price = itemDto.Price,
            };

            repo.UpdateItem(updatedItem);
            return NoContent();
        }
        //Delete /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repo.GetItem(id);
            if(existingItem is null)
            {
                return NotFound();
            }

            repo.DeleteItem(id);
            return NoContent();
        }

    }
}
