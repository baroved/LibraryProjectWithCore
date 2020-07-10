using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerCoreLibrary.API;

namespace ServerCoreLibrary.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookGenreController : ControllerBase
    {
        private readonly IBookGenreService _bookGenreService;

        public BookGenreController(IBookGenreService bookGenreService)
        {
            _bookGenreService = bookGenreService;
        }

        [HttpPost("AddToBookGenre")]
        public async Task<bool> AddToBookGenre(IEnumerable<int> genresId)
        {
            return await _bookGenreService.AddToBookGenre(genresId);
        }
    }
}