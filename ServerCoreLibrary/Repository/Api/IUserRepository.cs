using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface IUserRepository
    {
        #region Methods
        Task<bool> AddUser(User newUser);
        Task<User> Login(User currentUser);
        Task<User> GetUserById(int id);
        #endregion

    }
}
