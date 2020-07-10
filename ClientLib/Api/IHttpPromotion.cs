using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Api
{
    public interface IHttpPromotion
    {
        #region Methods
        Task<IEnumerable<Promotion>> GetAllPromotionsAsync();
        #endregion
    }
}
