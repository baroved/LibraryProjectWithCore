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
    public class EditionController : ControllerBase
    {
        private readonly IEditionService _editionService;

        public EditionController(IEditionService editionService)
        {
            _editionService = editionService;
        }

        [HttpGet("GetAllEditions")]
        public async Task<IEnumerable<Edition>> GetEditionAsync()
        {
            return await _editionService.GetAllEditions();
        }
    }
}