using BusinessLogic.InputValidation;
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
    public class SaleRepository : ISaleRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<SaleRepository> _logger;
        #endregion

        #region Constructor
        public SaleRepository(DBContext dbContext, ILogger<SaleRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //buy item and return true if succeeded
        public async Task<bool> BuyItemAsync(Sale historySale)
        {
            try
            {
                var itemToUpdate = await _dbContext.AbstractItem.Where(item => item.Id == historySale.ItemId).FirstOrDefaultAsync();
                if (itemToUpdate != null)
                {
                    itemToUpdate.CopiesInStock--;
                }

                _dbContext.Sales.Add(historySale);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Sell item failed: {ex.Message}");
                return false;
            }

        }


        //get all history sale
        public async Task<IEnumerable<Sale>> GetAllHistorySales()
        {
            try
            {
                return await _dbContext.Sales.Include(c => c.Customer)
                    .Include(u => u.User)
                    .Include(i => i.Item).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all history list failed: {ex.Message}");
                return new List<Sale>();
            }

        }
        #endregion
    }
}
