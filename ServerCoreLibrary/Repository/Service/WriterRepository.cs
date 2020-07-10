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
    public class WriterRepository : IWriterRepository
    {
        #region Properties
        public ILogger<WriterRepository>  _logger { get; set; }
        private readonly DBContext _dbContext;
        #endregion

        #region Constructor
        public WriterRepository(DBContext dbContext, ILogger<WriterRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //get all writers
        public async Task<IEnumerable<Writer>> GetAllWriterAsync()
        {
            try
            {
                return await _dbContext.Writers.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Get all writers failed: {ex.Message}");
                return new List<Writer>(); 
            }
        }

        //get writer by id
        public async Task<Writer> GetWriterByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Writers.Where(item => item.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get writer by id failed: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
