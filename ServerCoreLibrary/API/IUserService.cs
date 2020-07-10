using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.API
{
    public interface IUserService
    {
        #region Methods
        Task<bool> Register(User newUser);
        Task<User> Login(User currentUser);
        #endregion

    }
}
