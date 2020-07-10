using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpPublisher : IHttpPublisher
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpPublisher(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url to getAsync for get all publishers
        public async Task<IEnumerable<Publisher>> GetAllPublishers()
        {
            return await _httpService.GetAsync <IEnumerable<Publisher>>("Publishers/GetPublishers");
        }
        #endregion
    }
}
