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
    public class UserRepository : IUserRepository
    {
        #region Properties
        private readonly DBContext _dbContext;
        private readonly ILogger<UserRepository> _logger;
        #endregion

        #region Constructor
        public UserRepository(DBContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        //check if user with current username is exists
        public async Task<bool> CheckIfUsernameNotInUsed(string userName)
        {
            try
            {
                var checkUser = await _dbContext.Users.Where(user => user.UserName == userName)
                .FirstOrDefaultAsync();
                if (checkUser != null)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Check If UserName In Used failed: {ex.Message}");
                return false;
            }

        }


        //get new user and return true if secceeded
        public async Task<bool> AddUser(User newUser)
        {
            try
            {
                bool checkUserName = await CheckIfUsernameNotInUsed(newUser.UserName);
                if (!checkUserName)
                    return false;
                else
                {
                    _dbContext.Users.Add(newUser);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add user failed: {ex.Message}");
                return false;
            }

        }

        //return object of ValidationUserResponse if secceeded and if admin
        public async Task<User> Login(User currentUser)
        {
            try
            {
                return await _dbContext.Users.Where(user => user.UserName == currentUser.UserName
                       && user.Password == currentUser.Password).FirstOrDefaultAsync();

            }

            catch (Exception ex)
            {
                _logger.LogError($"Login failed: {ex.Message}");
                return null;
            }

        }

        //get user by id
        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _dbContext.Users.Where(user => user.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get user by id failed: {ex.Message}");
                return null;
            }

        }
        #endregion
    }
}
