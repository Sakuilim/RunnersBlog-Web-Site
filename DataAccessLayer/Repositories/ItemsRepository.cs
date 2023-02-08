using DataAccessLayer.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        public Task CreateItemAsync(Item item, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(Guid Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(Guid Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetItemsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(Item item, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
