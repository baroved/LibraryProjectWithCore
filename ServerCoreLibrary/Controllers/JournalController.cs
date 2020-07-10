using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerCoreLibrary.API;
using Shared.Model;

namespace ServerCoreLibrary.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournalService _journalService;

        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpPost("AddJournal")]
        public async Task<bool> AddJournal(Journal newJournal)
        {
            if (ModelState.IsValid)
                return await _journalService.AddJournalAsync(newJournal);
            return false;
        }

        [HttpPost("UpdateJournal")]
        public async Task<bool> UpdateJournal([FromBody]Journal item)
        {
            if (ModelState.IsValid)
                return await _journalService.UpdateJournalAsync(item);
            return false;
        }

        [HttpPost("GetJournal/{journalId}")]
        public async Task<Journal> GetJournalById(int journalId)
        {
            return await _journalService.GetJournalById(journalId);

        }
    }
}