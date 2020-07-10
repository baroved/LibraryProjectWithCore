using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.API
{
    public interface IJournalService
    {
        #region Methods
        Task<bool> AddJournalAsync(Journal newJournal);
        Task<bool> UpdateJournalAsync(Journal item);
        Task<Journal> GetJournalById(int journalId);
        #endregion

    }
}
