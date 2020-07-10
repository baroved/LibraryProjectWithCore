using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.API
{
    public interface ISaleService
    {
        #region Methods
        Task<IEnumerable<Sale>> GetHistorySalesAsync();
        Task<bool> BuyItemAsync(Sale historySale);
        #endregion
    }
}
