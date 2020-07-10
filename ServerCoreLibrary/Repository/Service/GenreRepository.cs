using Microsoft.EntityFrameworkCore;
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
    public class GenreRepository : IGenreRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<GenreRepository> _logger;
        #endregion

        #region Constructor                                                                                                                                                                                             
        public GenreRepository(DBContext dbContext, ILogger<GenreRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //get all genres
        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            try
            {
                return await _dbContext.Genre.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all genres failed: {ex.Message}");
                return new List<Genre>();
            }
        }

        //get genre by id
        public async Task<Genre> GetGenreById(int id)
        {
            try
            {
                return await _dbContext.Genre.Where(item => item.Id == id).FirstOrDefaultAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError($"Get genre by id failed: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
