using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;

namespace RunnersBlogMVC
{
    public static class Extensions
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
