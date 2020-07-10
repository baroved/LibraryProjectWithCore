using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface IGenreRepository
    {
        #region Methods
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreById(int id);
        #endregion
    }
}
