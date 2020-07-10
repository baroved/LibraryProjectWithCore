using Microsoft.Extensions.Logging;
using ServerCoreLibrary.DAL;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Service
{
    public class BookGenreRepository : IBookGenreRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<BookGenreRepository> _logger;
        #endregion

        #region Constructor
        public BookGenreRepository(DBContext dbContext, ILogger<BookGenreRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //add genres to newbook
        public async Task<bool> AddGenresToBookAsync(IEnumerable<int> genresId)
        {
            try
            {
                var bookId = _dbContext.Books.Last().Id;
                bool flag = false;
                if (genresId.Any())
                {
                    foreach (var genreId in genresId)
                    {
                        var BookGenre = new BookGenre
                        {
                            BookId = bookId,
                            GenreId = genreId
                        };

                        _dbContext.BookGenres.Add(BookGenre);
                        await _dbContext.SaveChangesAsync();
                        flag = true;
                    }

                }
                else
                    flag = false;
                return flag;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add genres to book failed: {ex.Message}");
                return false;
            }
        }
        #endregion
    }
}
