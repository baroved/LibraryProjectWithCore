using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface ICustomerRepository
    {
        #region Methods
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerById(int id);
        #endregion
    }
}
