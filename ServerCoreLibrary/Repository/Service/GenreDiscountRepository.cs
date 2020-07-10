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
    public class GenreDiscountRepository : IGenreDiscountRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<GenreDiscountRepository> _logger;
        #endregion

        #region Constructor
        public GenreDiscountRepository(DBContext dbContext, ILogger<GenreDiscountRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion


        #region Methods
        //get genre discount by id
        public async Task<GenreDiscount> GetGenreDiscountById(int? id)
        {
            try
            {
                return await _dbContext.GenresDiscount.Where(item => item.Id == id).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"GetGenreDiscountById failed: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
