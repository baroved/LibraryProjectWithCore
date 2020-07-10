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
    public class WritersController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WritersController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet("GetAllWriters")]
        public async Task<IEnumerable<Writer>> GetAllWriters()
        {
            return await _writerService.GetAllWritersAsync();
        }
    }
}