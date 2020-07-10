using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpWriter : IHttpWriter
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpWriter(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url to getAsync for get all writers
        public async Task<IEnumerable<Writer>> GetAllWriters()
        {
            return await _httpService.GetAsync<IEnumerable<Writer>>("Writers/GetAllWriters");
        }
        #endregion
    }
}
