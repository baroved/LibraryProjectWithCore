using BusinessLogic.InputValidation;
using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class SaleService : ISaleService
    {
        #region Properties
        private readonly ISaleRepository _historySaleRepository;
        private readonly ValidationInputs _validation;
        #endregion

        #region Constructor
        public SaleService(ISaleRepository historySaleRepository, ValidationInputs validation)
        {
            _historySaleRepository = historySaleRepository;
            _validation = validation;
        }
        #endregion

        #region Methods
        public async Task<bool> BuyItemAsync(Sale historySale)
        {
            bool ok = _validation.ValidForBuying(historySale);
            if (ok)
                return await _historySaleRepository.BuyItemAsync(historySale);
            return false;
        }

        public async Task<IEnumerable<Sale>> GetHistorySalesAsync()
        {
            return await _historySaleRepository.GetAllHistorySales();
        }
        #endregion
    }
}
