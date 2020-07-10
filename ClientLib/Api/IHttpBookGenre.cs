using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Api
{
    public interface IHttpBookGenre
    {
        #region Methods
        Task<bool> AddToBookGenre(IEnumerable<int> genresId);
        #endregion
    }
}
