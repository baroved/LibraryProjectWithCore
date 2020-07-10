using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Api
{
    public interface IHttpSale
    {
        #region Methods
        Task<IEnumerable<Sale>> GetAllHistorySales();
        Task<bool> BuyItemAsync(Sale historySale);
        #endregion
    }
}
