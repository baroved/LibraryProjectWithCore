using ClientLib.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpBookGenre : IHttpBookGenre
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpBookGenre(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url and list of genres id to postAsync for add to book genre table
        public async Task<bool> AddToBookGenre(IEnumerable<int> genresId)
        {
            return await _httpService.PostAsync<IEnumerable<int>, bool>("BookGenre/AddToBookGenre", genresId);
        }
        #endregion
    }
}
