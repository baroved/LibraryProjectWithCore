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
    public class EditionRepository : IEditionRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<EditionRepository> _logger;
        #endregion

        #region Constructor
        public EditionRepository(DBContext dbContext, ILogger<EditionRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion


        #region Methods
        //get all editions
        public async Task<IEnumerable<Edition>> GetAllEditions()
        {
            try
            {
                return await _dbContext.Edition.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all editions failed: {ex.Message}");
                return new List<Edition>();
            }
        }
        #endregion
    }
}
