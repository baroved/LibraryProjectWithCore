using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface IWriterRepository
    {
        #region Methods
        Task<IEnumerable<Writer>> GetAllWriterAsync();
        Task<Writer> GetWriterByIdAsync(int id);
        #endregion
    }
}
