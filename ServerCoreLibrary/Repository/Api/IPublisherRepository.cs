using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface IPublisherRepository
    {
        #region Methods
        Task<IEnumerable<Publisher>> GetAllPublisherAsync();
        Task<Publisher> GetPublisherById(int id);
        #endregion
    }
}
