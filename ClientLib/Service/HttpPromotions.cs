using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpPromotions : IHttpPromotion
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpPromotions(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url to getAsync for get all promotions
        public async Task<IEnumerable<Promotion>> GetAllPromotionsAsync()
        {
            return await _httpService.GetAsync<IEnumerable<Promotion>>("Promotion/GetPromotions");
        }
        #endregion
    }
}
