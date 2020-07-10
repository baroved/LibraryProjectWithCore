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
    public class PromotionsRepository : IPromotionRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<PromotionsRepository> _logger;
        #endregion

        #region Constructor
        public PromotionsRepository(DBContext dbContext, ILogger<PromotionsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Promotion>> GetAllPromotionsAsync()
        {
            try
            {
                return await _dbContext.Promotions.Include(pd => pd.PublisherDiscount).Include(p => p.PublisherDiscount.Publisher)
                    .Include(wd => wd.WriterDiscount).Include(w => w.WriterDiscount.Writer)
                    .Include(gd => gd.GenreDiscount).Include(g => g.GenreDiscount.Genre).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all promotion failed: {ex.Message}");
                return new List<Promotion>();
            }

        }
        #endregion
    }
}
