using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class BookGenreService : IBookGenreService
    {
        #region Properties
        private readonly IBookGenreRepository _bookGenreRepository;
        #endregion

        #region Constructor
        public BookGenreService(IBookGenreRepository bookGenreRepository)
        {
            _bookGenreRepository = bookGenreRepository;
        }
        #endregion

        #region Methods
        public async Task<bool> AddToBookGenre(IEnumerable<int> genresId)
        {
            return await _bookGenreRepository.AddGenresToBookAsync(genresId);
        }
        #endregion
    }
}
