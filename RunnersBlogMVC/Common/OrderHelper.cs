using RunnersBlogMVC.Models;

namespace RunnersBlogMVC.Common
{
    public class OrderHelper : IOrderHelper
    {
        public List<Item> OrderByColumn(List<Item> itemsToSort, string orderByColumn)
        {
            switch(orderByColumn)
            {
                case "Price":
                    itemsToSort = itemsToSort.OrderBy(x => x.Price).ToList();
                    return itemsToSort;

                default:
                    return itemsToSort;
            }
        }
    }
}
