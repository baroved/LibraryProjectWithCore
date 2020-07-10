using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Api
{
    public interface IHttpJournal
    {
        #region Methods
        Task<bool> AddJournalAsync(Journal newJournal);
        Task<bool> UpdateJournalAsync(Journal item);
        Task<Journal> GetJournalById(int journalId);
        #endregion
    }
}
