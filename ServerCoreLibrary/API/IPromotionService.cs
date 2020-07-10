using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.API
{
    public interface IPromotionService
    {
        #region Methods
        Task<IEnumerable<Promotion>> GetAllPromotionsAsync();
        #endregion
    }
}
