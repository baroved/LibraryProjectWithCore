using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerCoreLibrary.API;
using Shared.BookResponse;
using Shared.Model;

namespace ServerCoreLibrary.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;
        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet("Items")]
        public async Task<IEnumerable<AbstractItem>> GetAllItems()
        {
            return await _itemsService.GetAllItemsAsync();
        }

        [HttpGet("Item/{itemId}")]
        public async Task<AbstractItem> GetItemById(int itemId)
        {
            return await _itemsService.GetItemById(itemId);
        }

        [HttpGet("ItemsByPublisherDiscount/{name}")]
        public async Task<IEnumerable<AbstractItem>> GetItemsByPublisherDiscount(string name)
        {
            return await _itemsService.GetItemsByPublisherDiscount(name);
        }

        [HttpGet("ItemsByWriterDiscount/{name}")]
        public async Task<IEnumerable<AbstractItem>> GetItemsByWriterDiscount(string name)
        {
            return await _itemsService.GetItemsByWriterDiscount(name);
        }

        [HttpGet("ItemsByGenreDiscount/{name}")]
        public async Task<IEnumerable<AbstractItem>> GetItemsByGenreDiscount(string name)
        {
            return await _itemsService.GetItemsByGenreDiscount(name);
        }

        [HttpGet("ItemsByTypeDiscount/{name}")]
        public async Task<IEnumerable<AbstractItem>> GetItemsByTypeDiscount(string name)
        {
            return await _itemsService.GetItemsDiscountByType(name);
        }

    }
}