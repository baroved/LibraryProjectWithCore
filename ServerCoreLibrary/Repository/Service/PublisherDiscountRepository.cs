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
    public class PublisherDiscountRepository:IPublisherDiscountRepository
    {
        #region Properties
        private DBContext _dbContext { get; set; }
        private readonly ILogger<PublisherDiscountRepository> _logger;
        #endregion

        #region Constructor
        public PublisherDiscountRepository(DBContext dbContext, ILogger<PublisherDiscountRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //get publisher discount by id
        public async Task<PublisherDiscount> GetPublisherDiscountById(int? id)
        {
            try
            {
                return await _dbContext.PublishersDiscount.Where(item => item.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get publisher discount by id failed: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
