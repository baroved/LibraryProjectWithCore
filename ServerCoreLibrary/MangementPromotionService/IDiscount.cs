using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.MangementPromotionService
{
    public interface IDiscount
    {
        #region Methods
        Task<int> GetDiscount(AbstractItem item);
        Task<int> GetDiscountByPublisher(int publisherId);
        Task<int> GetDiscountByGenre(int genresId);
        Task<IEnumerable<int>> GetGenresIdByBookId(int bookId);
        Task<int> GetDiscountByWriter(int writerId);
        #endregion

    }
}
