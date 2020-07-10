using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class GenreService : IGenreService
    {
        #region Properties
        private readonly IGenreRepository _genreRepository;
        #endregion

        #region Constructor
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _genreRepository.GetAllGenresAsync();
        }
        #endregion
    }
}
