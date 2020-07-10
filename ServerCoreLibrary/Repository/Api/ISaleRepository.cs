using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface ISaleRepository
    {
        #region Methods
        Task<IEnumerable<Sale>> GetAllHistorySales();
        Task<bool> BuyItemAsync(Sale historySale);
        #endregion
    }
}
