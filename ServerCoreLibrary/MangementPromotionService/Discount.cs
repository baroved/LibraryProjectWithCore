using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServerCoreLibrary.DAL;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.MangementPromotionService
{
    public class Discount : IDiscount
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<Discount> _logger;
        #endregion

        #region Constructor
        public Discount(DBContext dbContext, ILogger<Discount> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //searching all discount by item and return a biggest discount
        public async Task<int> GetDiscount(AbstractItem item)
        {
            int discountByPublisher = await GetDiscountByPublisher(item.PublisherId);//get discount by publisherid
            if (item is Book)
            {
                var genresIdList = await GetGenresIdByBookId(item.Id);//get genresid list by bookid for get biggest discount from genres 
                List<int> discountOfAllGenres = new List<int>();
                foreach (var i in genresIdList)
                {
                    var discountByGenre = await GetDiscountByGenre(i);
                    discountOfAllGenres.Add(discountByGenre);//add discountgenres to a list
                }
                var biggestGenreDiscount = discountOfAllGenres.Max();//get biggest discount from genreslist
                int discountByWriter = await GetDiscountByWriter(((Book)item).WriterId);
                int bigger = Math.Max(discountByPublisher, discountByWriter);
                int biggest = Math.Max(biggestGenreDiscount, bigger);
                return biggest;
            }
            return discountByPublisher;
        }

        //get list of genres by bookid
        public async Task<IEnumerable<int>> GetGenresIdByBookId(int bookId)
        {
            try
            {
                var list = await _dbContext.BookGenres.Where(item => item.BookId == bookId).Select(a => a.GenreId).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get list genresId By book id failed: {ex.Message}");
                return null;
            }
        }

        public async Task<int> GetDiscountByGenre(int genresId)
        {
            try
            {
                var genresDiscount = await _dbContext.GenresDiscount.Where(i => i.GenreId == genresId).FirstOrDefaultAsync();
                if (genresDiscount != null)
                {
                    if (await CheckDateValidationGenreDiscount(genresDiscount.Id))//check validation on datetime.now
                        return genresDiscount.Percent;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get discount by genre failed: {ex.Message}");
                return 0;
            }
        }

        //get publisher discount by publisherid 
        public async Task<int> GetDiscountByPublisher(int publisherId)
        {
            try
            {
                var publisherDiscount = await _dbContext.PublishersDiscount.Where(i => i.PublisherId == publisherId).FirstOrDefaultAsync();
                if (publisherDiscount != null)
                {
                    if (await CheckDateValidationPublisherDiscount(publisherDiscount.Id))
                        return publisherDiscount.Percent;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get discount by publisher failed: {ex.Message}");
                return 0;
            }
        }

        //get writer discount by writerid
        public async Task<int> GetDiscountByWriter(int writerId)
        {
            try
            {
                var WriterDiscount = await _dbContext.WritersDiscount.Where(i => i.WriterId == writerId).FirstOrDefaultAsync();
                if (WriterDiscount != null)
                {
                    if (await CheckDateValidationWriterDiscount(WriterDiscount.Id))
                        return WriterDiscount.Percent;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get discount by writer failed: {ex.Message}");
                return 0;
            }
        }

        //check validation on datetime.now
        public async Task<bool> CheckDateValidationPublisherDiscount(int PublisherDisocuntId)
        {
            try
            {
                var promotion = await _dbContext.Promotions.Where(item => item.PublisherDiscountId == PublisherDisocuntId).FirstOrDefaultAsync();
                return (DateTime.Now.Ticks >= promotion.DateStart.Ticks && DateTime.Now.Ticks <= promotion.DateEnd.Ticks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Check date validation failed: {ex.Message}");
                return false;
            }
        }


        //check validation on datetime.now
        public async Task<bool> CheckDateValidationWriterDiscount(int writerDiscountId)
        {
            try
            {
                var promotion = await _dbContext.Promotions.Where(item => item.WriterDiscountId == writerDiscountId).FirstOrDefaultAsync();
                return (DateTime.Now.Ticks >= promotion.DateStart.Ticks && DateTime.Now.Ticks <= promotion.DateEnd.Ticks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Check date validation failed: {ex.Message}");
                return false;
            }
        }



        //check validation on datetime.now
        public async Task<bool> CheckDateValidationGenreDiscount(int genreDiscountId)
        {
            try
            {
                var promotion = await _dbContext.Promotions.Where(item => item.GenreDiscountId == genreDiscountId).FirstOrDefaultAsync();
                return (DateTime.Now.Ticks >= promotion.DateStart.Ticks && DateTime.Now.Ticks <= promotion.DateEnd.Ticks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Check date validation failed: {ex.Message}");
                return false;
            }
        }
        #endregion
    }
}
