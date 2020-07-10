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
    public class WriterDiscountRepository : IWriterDiscountRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<WriterDiscountRepository> _logger;
        #endregion

        #region Constructor
        public WriterDiscountRepository(DBContext dbContext, ILogger<WriterDiscountRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //get writer discount by id
        public async Task<WriterDiscount> GetWriterDiscountById(int? id)
        {
            try
            {
                return await _dbContext.WritersDiscount.Where(item => item.Id == id).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Get writer discount by id failed: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
