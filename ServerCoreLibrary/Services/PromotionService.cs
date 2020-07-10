using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class PromotionService : IPromotionService
    {
        #region Properties
        private readonly IPromotionRepository _promotionRepository;
        #endregion

        #region Constructor
        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Promotion>> GetAllPromotionsAsync()
        {

            return await _promotionRepository.GetAllPromotionsAsync();
        }
        #endregion
    }
}
