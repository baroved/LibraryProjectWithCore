using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.API
{
    public interface ICustomerService
    {
        #region Methods
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        #endregion
    }
}
