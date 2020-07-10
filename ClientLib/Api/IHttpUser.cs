using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Api
{
    public interface IHttpUser
    {
        #region Methods
        Task<bool> Register(User newUser);
        Task<User> Login(User currentUser);
        #endregion
    }
}
