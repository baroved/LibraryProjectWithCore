using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.API
{
    public interface IBookGenreService
    {
        #region Methods
        Task<bool> AddToBookGenre(IEnumerable<int> genresId);
        #endregion
    }
}
