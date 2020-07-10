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
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genresService;

        public GenresController(IGenreService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet("GetGenres")]
        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _genresService.GetAllGenresAsync();
        }
    }
}