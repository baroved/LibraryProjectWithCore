using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpSale : IHttpSale
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpSale(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url and history sale to postAsync for buy item
        public async Task<bool> BuyItemAsync(Sale historySale)
        {
            return await _httpService.PostAsync<Sale,bool>("Sale/Buy", historySale);
        }

        
        //send url to getAsync for get all history sales
        public async Task<IEnumerable<Sale>> GetAllHistorySales()
        {
            return await _httpService.GetAsyncJason<IEnumerable<Sale>>("Sale/GetHistorySales");
        }
        #endregion
    }
}
