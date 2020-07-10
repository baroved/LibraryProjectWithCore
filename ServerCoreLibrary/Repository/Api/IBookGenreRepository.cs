using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface IBookGenreRepository
    {
        #region Methods
        Task<bool> AddGenresToBookAsync(IEnumerable<int> genresId);
        #endregion
    }
}
