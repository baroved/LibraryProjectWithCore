using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServerCoreLibrary.DAL;
using ServerCoreLibrary.MangementPromotionService;
using ServerCoreLibrary.Repository.Api;
using Shared.BookResponse;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Service
{
    public class ItemRepository : IItemsRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly IDiscount _discountService;
        private readonly ILogger<ItemRepository> _logger;
        #endregion

        #region Constructor
        public ItemRepository(DBContext dbContext, IDiscount discountService, ILogger<ItemRepository> logger)
        {
            _dbContext = dbContext;
            _discountService = discountService;
            _logger = logger;
        }
        #endregion

        #region Methods
        //get all items
        public async Task<IEnumerable<AbstractItem>> GetAllItemsAsync()
        {
            try
            {
                var allItems = await _dbContext.AbstractItem.ToListAsync();
                foreach (var item in allItems)
                {
                    int discount = await _discountService.GetDiscount(item);
                    if (discount != 0)
                    {
                        item.Price -= item.Price * discount / 100;
                        item.Discount = discount;
                    }
                }
                return allItems;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all items failed: {ex.Message}");
                return new List<AbstractItem>();
            }
        }


        //get all items with discount by type
        public async Task<IEnumerable<AbstractItem>> GetItemsDiscountByType(string type)
        {
            try
            {
                List<AbstractItem> newList = new List<AbstractItem>();
                var list = await GetAllItemsAsync();
                var itemWithDiscount = list.Where(item => item.Discount > 0).ToList();
                if (type.ToLower() == "book")//set string to lower
                    newList = itemWithDiscount.Where(i => i is Book).ToList();
                else
                {
                    if (type.ToLower() == "journal")
                        newList = itemWithDiscount.Where(i => i is Journal).ToList();
                    else
                        return newList;
                }
                return newList;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Items with discount by type failed: {ex.Message}");
                return new List<AbstractItem>();
            }

        }


        //get item by id
        public async Task<AbstractItem> GetItemById(int id)
        {
            try
            {
                return await _dbContext.AbstractItem.Where(item => item.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get item by id: {ex.Message}");
                return null;
            }
        }


        //get all items with genre discount
        public async Task<IEnumerable<AbstractItem>> GetItemsByGenreDiscount(string name)
        {
            try
            {
                List<AbstractItem> newList = new List<AbstractItem>();
                var checkGenre = await _dbContext.Genre
                    .Where(item => item.Type.ToLower() == name.ToLower()).FirstOrDefaultAsync();//check if genre exists
                if (checkGenre == null)//return empty list if genre not exists
                    return newList;
                var items = await _dbContext.AbstractItem.Where(i => i is Book).ToListAsync();
                foreach (var item in items)
                {
                    var genresId = await _discountService.GetGenresIdByBookId(item.Id);//get list genres by item as Book
                    foreach (var genreId in genresId)
                    {
                        if (genreId == checkGenre.Id)//check if genre exists in genresid list
                        {
                            var discount = await _discountService.GetDiscountByGenre(genreId);
                            var finalDiscount = await _discountService.GetDiscount(item);
                            if (discount > 0)
                            {
                                item.Price -= item.Price * finalDiscount / 100;
                                item.Discount = discount;
                                newList.Add(item);
                            }
                        }
                    }
                }
                return newList;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get items by genre discount failed: {ex.Message}");
                return new List<AbstractItem>();
            }
        }

        //get items by publisher discount
        public async Task<IEnumerable<AbstractItem>> GetItemsByPublisherDiscount(string name)
        {
            try
            {
                List<AbstractItem> newList = new List<AbstractItem>();
                var checkPublisher = await _dbContext.Publishers
                    .Where(item => item.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();//check if publisher exists
                if (checkPublisher == null)
                    return newList;
                var items = await _dbContext.AbstractItem.ToListAsync();
                foreach (var item in items)
                {
                    if (item.PublisherId == checkPublisher.Id)//check if item with the same publisherid exists
                    {
                        var discount = await _discountService.GetDiscountByPublisher(item.PublisherId);
                        var finalDiscount = await _discountService.GetDiscount(item);
                        if (discount > 0)
                        {
                            item.Price -= item.Price * finalDiscount / 100;
                            item.Discount = discount;
                            newList.Add(item);
                        }
                    }
                }
                return newList;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get items by publisher discount failed: {ex.Message}");
                return new List<AbstractItem>();
            }

        }

        //get item with writer discount
        public async Task<IEnumerable<AbstractItem>> GetItemsByWriterDiscount(string name)
        {
            try
            {
                List<AbstractItem> newList = new List<AbstractItem>();
                var checkWriter = await _dbContext.Writers
                    .Where(item => item.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();//check if writer exists
                if (checkWriter == null)//if writer is not exists return empty list
                    return newList;
                var items = await _dbContext.AbstractItem.ToListAsync();
                foreach (var item in items)
                {
                    if (item is Book)
                    {
                        if (((Book)item).WriterId == checkWriter.Id)//if item is Book check if writerid and check writer is the same
                        {
                            var discount = await _discountService.GetDiscountByWriter(((Book)item).WriterId);
                            var finalDiscount = await _discountService.GetDiscount(item);
                            if (discount > 0)
                            {
                                item.Price -= item.Price * finalDiscount / 100;
                                item.Discount = discount;
                                newList.Add(item);
                            }
                        }
                    }
                }
                return newList;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get items by writer discount failed: {ex.Message}");
                return new List<AbstractItem>();
            }
        }

        #endregion

    }
}
