using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Api
{
    public interface IHttpEdition
    {
        #region Methods
        Task<IEnumerable<Edition>> GetAllEditionsAsync();
        #endregion
    }
}
