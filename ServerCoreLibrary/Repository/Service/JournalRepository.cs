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
    public class JournalRepository : IJournalRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<JournalRepository> _logger;
        #endregion

        #region Constructor
        public JournalRepository(DBContext dbContext, ILogger<JournalRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //get add journal and return true if succeeded
        public async Task<bool> AddJournalAsync(Journal newJournal)
        {
            try
            {
                _dbContext.Journals.Add(newJournal);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add journal failed: {ex.Message}");
                return false;
            }

        }


        //get journal by id
        public async Task<Journal> GetJournalById(int journalId)
        {
            try
            {
                return await _dbContext.Journals.Where(item => item.Id == journalId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get journal by id failed: {ex.Message}");
                return null;
            }
        }


        //return true if update journal is secceeded
        public async Task<bool> UpdateJournalAsync(Journal item)
        {
            try
            {
                var checkItem = await _dbContext.AbstractItem.Where(i => i.Id == item.Id).FirstOrDefaultAsync();
                if (checkItem != null)
                {
                    checkItem.Name = item.Name;
                    checkItem.Description = item.Description;
                    checkItem.CopiesInStock = item.CopiesInStock;
                    checkItem.Price = item.Price;
                    checkItem.ImgUrl = item.ImgUrl;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update journal failed: {ex.Message}");
                return false;
            }
        }
        #endregion
    }
}
