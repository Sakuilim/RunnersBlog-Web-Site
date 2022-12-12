using RunnersBlogMVC.Models;

namespace RunnersBlogMVC.Common
{
    public interface IOrderHelper
    {
        public List<Item> OrderByColumn(List<Item> itemsToSort, string orderByColumn);
    }
}