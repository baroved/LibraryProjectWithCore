using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServerCoreLibrary.DAL;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Service
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<CustomerRepository> _logger;
        #endregion

        #region Constructor
        public CustomerRepository(DBContext dbContext, ILogger<CustomerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //get all customers
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            try
            {
                return await _dbContext.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all customers failed: {ex.Message}");
                return new List<Customer>();
            }
        }

        //get customer by id
        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                return await _dbContext.Customers.Where(customer => customer.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get customer by id failed: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
