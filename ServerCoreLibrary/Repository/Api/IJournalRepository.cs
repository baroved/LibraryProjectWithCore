using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface IJournalRepository
    {
        #region Methods
        Task<bool> AddJournalAsync(Journal newJournal);
        Task<bool> UpdateJournalAsync(Journal item);
        Task<Journal> GetJournalById(int journalId);
        #endregion
    }
}
