using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.API
{
    public interface IGenreService
    {
        #region Methods
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        #endregion
    }
}
