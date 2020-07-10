using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface IGenreDiscountRepository
    {
        #region Methods
        Task<GenreDiscount> GetGenreDiscountById(int? id);
        #endregion
    }
}
