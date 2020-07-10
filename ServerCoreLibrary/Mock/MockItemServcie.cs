using ServerCoreLibrary.API;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Mock
{
    public class MockItemServcie : IItemsService
    {
        public IEnumerable<AbstractItem> Items { get; set; }

        public MockItemServcie()
        {
            Items = new List<AbstractItem>()
            {
                new Book{Id=1,Name="bbb",CopiesInStock=10,Price=34.9,Description="sfg",PublisherId=1,
                WriterId=1},

                new Journal{Id=2,Name="ccc",CopiesInStock=10,Price=34.9,Description="sfg",PublisherId=1,
                EditionId=1},

                new Journal{Id=3,Name="aaa",CopiesInStock=10,Price=34.9,Description="sfg",PublisherId=1,
                EditionId=2}
            };
        }
        public Task<IEnumerable<AbstractItem>> GetAllItemsAsync()
        {
            return Task.FromResult(Items);
        }

        public Task<AbstractItem> GetItemById(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AbstractItem>> GetItemsByGenreDiscount(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AbstractItem>> GetItemsByPublisherDiscount(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AbstractItem>> GetItemsByWriterDiscount(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AbstractItem>> GetItemsDiscountByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
