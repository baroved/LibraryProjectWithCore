using BusinessLogic.InputValidation;
using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class JournalService : IJournalService
    {
        #region Properties
        private readonly IJournalRepository _journalRepository;
        private readonly ValidationInputs _validation;
        #endregion

        #region Constructor
        public JournalService(IJournalRepository journalRepository, ValidationInputs validation)
        {
            _journalRepository = journalRepository;
            _validation = validation;
        }
        #endregion

        #region Methods
        public async Task<bool> AddJournalAsync(Journal newJournal)
        {
            bool ok = _validation.ValidForAddJournal(newJournal);
            if (ok)
                return await _journalRepository.AddJournalAsync(newJournal);
            return false;
        }

        public async Task<Journal> GetJournalById(int journalId)
        {
            return await _journalRepository.GetJournalById(journalId);
        }

        public async Task<bool> UpdateJournalAsync(Journal item)
        {
            bool ok = _validation.ValidUpdatedItem(item);
            if (ok)
                return await _journalRepository.UpdateJournalAsync(item);
            return false;
        }
        #endregion
    }
}
