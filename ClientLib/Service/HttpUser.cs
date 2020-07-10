using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpUser : IHttpUser
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpUser(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        ////send url and user to postAsync for login
        public async Task<User> Login(User currentUser)
        {
            return await _httpService.PostAsync<User, User>("Users/Login", currentUser);
        }

        //send url and new user to postAsync for add user
        public async Task<bool> Register(User newUser)
        {
            return await _httpService.PostAsync<User, bool>("Users/Register", newUser);
        }
        #endregion
    }
}
