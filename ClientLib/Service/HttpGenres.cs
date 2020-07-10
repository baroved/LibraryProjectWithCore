using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpGenres : IHttpGenres
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpGenres(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url to getAsync for get all genres
        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _httpService.GetAsync<IEnumerable<Genre>>("Genres/GetGenres");
        }
        #endregion




    }
}
