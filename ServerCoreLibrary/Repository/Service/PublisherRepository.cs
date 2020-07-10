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
    public class PublisherRepository : IPublisherRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<PublisherRepository> _logger;
        #endregion

        #region Constructor
        public PublisherRepository(DBContext dbContext, ILogger<PublisherRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //get all publishers
        public async Task<IEnumerable<Publisher>> GetAllPublisherAsync()
        {
            try
            {
                return await _dbContext.Publishers.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all publisher failed: {ex.Message}");
                return new List<Publisher>();
            }
        }

        //get publisher by id
        public async Task<Publisher> GetPublisherById(int id)
        {
            try
            {
                return await _dbContext.Publishers.Where(item => item.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get publisher by id failed: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
