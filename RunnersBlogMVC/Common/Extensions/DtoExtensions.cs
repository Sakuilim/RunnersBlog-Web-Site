using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;

namespace RunnersBlogMVC
{
    public static class DtoExtensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Name = item.Name,
                Price = item.Price
            };  

        }
    }
}
