using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpEdition : IHttpEdition
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpEdition(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url to getAsync for get all editions
        public async Task<IEnumerable<Edition>> GetAllEditionsAsync()
        {
           return await _httpService.GetAsync<IEnumerable<Edition>>("Edition/GetAllEditions");
        }
        #endregion
    }
}
