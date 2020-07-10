using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpCustomer : IHttpCustomer
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpCustomer(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url to getAsync for get all customers
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _httpService.GetAsync<IEnumerable<Customer>>("Customers/Customers");
        }
        #endregion


    }
}
