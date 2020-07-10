using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using Shared.BookResponse;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class ItemsService : IItemsService
    {
        #region Properties
        private readonly IItemsRepository _itemsRepository;
        #endregion

        #region Constructor
        public ItemsService(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<AbstractItem>> GetAllItemsAsync()
        {
            return await _itemsRepository.GetAllItemsAsync();
        }

        public async Task<AbstractItem> GetItemById(int itemId)
        {
            return await _itemsRepository.GetItemById(itemId);
        }

        public async Task<IEnumerable<AbstractItem>> GetItemsByGenreDiscount(string name)
        {
            return await _itemsRepository.GetItemsByGenreDiscount(name);
        }

        public async Task<IEnumerable<AbstractItem>> GetItemsByPublisherDiscount(string name)
        {
            return await _itemsRepository.GetItemsByPublisherDiscount(name);
        }

        public async Task<IEnumerable<AbstractItem>> GetItemsByWriterDiscount(string name)
        {
            return await _itemsRepository.GetItemsByWriterDiscount(name);
        }

        public async Task<IEnumerable<AbstractItem>> GetItemsDiscountByType(string type)
        {
            return await _itemsRepository.GetItemsDiscountByType(type);
        }
        #endregion
    }
}
