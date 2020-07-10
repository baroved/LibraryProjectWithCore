using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface IEditionRepository
    {
        #region Methods
        Task<IEnumerable<Edition>> GetAllEditions();
        #endregion
    }
}
