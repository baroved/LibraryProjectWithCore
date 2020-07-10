using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpJournal:IHttpJournal
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpJournal(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url and journal to postAsync for add journal
        public async Task<bool> AddJournalAsync(Journal newJournal)
        {
            return await _httpService.PostAsync<Journal, bool>("Journal/AddJournal", newJournal);
        }

        //send url and journalId to getAsync for get journal by id
        public async Task<Journal> GetJournalById(int journalId)
        {
            return await _httpService.GetAsync<Journal>($"Journal/AddJournal/{journalId}");
        }

        //send url and journal to postAsync for update journal
        public async Task<bool> UpdateJournalAsync(Journal item)
        {
            return await _httpService.PostAsync<Journal, bool>("Journal/UpdateJournal", item);
        }
        #endregion
    }
}
