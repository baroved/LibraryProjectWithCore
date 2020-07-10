using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServerCoreLibrary.DAL;
using ServerCoreLibrary.MangementPromotionService;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Service
{
    public class BookRepository : IBookRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly IDiscount _discountService;
        private readonly ILogger<BookRepository> _logger;
        #endregion

        #region Constructor
        public BookRepository(DBContext dbContext, IDiscount discountService, ILogger<BookRepository> logger)
        {
            _dbContext = dbContext;
            _discountService = discountService;
            _logger = logger;
        }
        #endregion

        #region Methods
        //get new book and return true if succeeded
        public async Task<bool> AddBookAsync(Book newBook)
        {
            try
            {
                _dbContext.Books.Add(newBook);
                await _dbContext.SaveChangesAsync();
                return true;
            }


            catch (Exception ex)
            {
                _logger.LogError($"Add book failed: {ex.Message}");
                return false;
            }

        }

        //get book by id
        public async Task<Book> GetBookById(int bookId)
        {
            try
            {
                var book = await _dbContext.Books.Where(item => item.Id == bookId).FirstOrDefaultAsync();
                if (book != null)
                    return book;
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get book by id failed: {ex.Message}");
                return null;
            }
        }

        //update book and return true is succeeded
        public async Task<bool> UpdateBookAsync(Book item)
        {
            try
            {
                var checkItem = await _dbContext.AbstractItem.Where(i => i.Id == item.Id).FirstOrDefaultAsync();
                if (checkItem != null)
                {
                    checkItem.Name = item.Name;
                    checkItem.Description = item.Description;
                    checkItem.CopiesInStock = item.CopiesInStock;
                    checkItem.Price = item.Price;
                    checkItem.ImgUrl = item.ImgUrl;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update book failed: {ex.Message}");
                return false;
            }
        }
        #endregion
    }
}
