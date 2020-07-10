using Shared.BookResponse;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface IItemsRepository
    {
        #region Methods
        Task<IEnumerable<AbstractItem>> GetAllItemsAsync();
        Task<AbstractItem> GetItemById(int id);
        Task<IEnumerable<AbstractItem>> GetItemsByPublisherDiscount(string name);
        Task<IEnumerable<AbstractItem>> GetItemsByWriterDiscount(string name);
        Task<IEnumerable<AbstractItem>> GetItemsByGenreDiscount(string name);
        Task<IEnumerable<AbstractItem>> GetItemsDiscountByType(string type);
        #endregion
    }
}
