using ClientLib.Api;
using Shared.BookResponse;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpItem : IHttpItem
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpItem(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url to getAsyncJason to get all items
        public async Task<IEnumerable<AbstractItem>> GetAllItems()
        {
            return await _httpService.GetAsyncJason<IEnumerable<AbstractItem>>("Items/Items");
        }

        //send url and item id to GetAsyncJason to get item by id
        public async Task<AbstractItem> GetItemById(int idItem)
        {
            return await _httpService.GetAsyncJason<AbstractItem>($"Items/Item/{idItem}");
        }

        //send url and name to GetAsyncJason to get items by genre discount
        public async Task<IEnumerable<AbstractItem>> GetItemsByGenreDiscount(string name)
        {
            return await _httpService.GetAsyncJason<IEnumerable<AbstractItem>>($"Items/ItemsByGenreDiscount/{name}");
        }

        //send url and name to GetAsyncJason to get items by publisher discount
        public async Task<IEnumerable<AbstractItem>> GetItemsByPublisherDiscount(string name)
        {
            return await _httpService.GetAsyncJason<IEnumerable<AbstractItem>>($"Items/ItemsByPublisherDiscount/{name}");
        }

        //send url and name to GetAsyncJason to get items by type discount
        public async Task<IEnumerable<AbstractItem>> GetItemsByTypeDiscount(string name)
        {
            return await _httpService.GetAsyncJason<IEnumerable<AbstractItem>>($"Items/ItemsByTypeDiscount/{name}");
        }

        //send url and name to GetAsyncJason to get items by writer discount
        public async Task<IEnumerable<AbstractItem>> GetItemsByWriterDiscount(string name)
        {
            return await _httpService.GetAsyncJason<IEnumerable<AbstractItem>>($"Items/ItemsByWriterDiscount/{name}");
        }
        #endregion
    }
}
