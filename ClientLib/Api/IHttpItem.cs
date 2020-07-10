using Shared.BookResponse;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Api
{
    public interface IHttpItem
    {
        #region Methods
        Task<IEnumerable<AbstractItem>> GetAllItems();
        Task<AbstractItem> GetItemById(int idItem);
        Task<IEnumerable<AbstractItem>> GetItemsByPublisherDiscount(string name);
        Task<IEnumerable<AbstractItem>> GetItemsByWriterDiscount(string name);
        Task<IEnumerable<AbstractItem>> GetItemsByGenreDiscount(string name);
        Task<IEnumerable<AbstractItem>> GetItemsByTypeDiscount(string name);
        #endregion
    }
}
