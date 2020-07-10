using BusinessLogic.UserValidation;
using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class UserService : IUserService
    {
        #region Properties
        private readonly IUserRepository _userRepository;
        private readonly UserValidation _validation;
        #endregion

        #region Constructor
        public UserService(IUserRepository userRepository, UserValidation validation)
        {
            _userRepository = userRepository;
            _validation = validation;
        }
        #endregion

        #region Methods
        public async Task<User> Login(User currentUser)
        {
            bool ok = _validation.Login(currentUser);
            if (ok)
                return await _userRepository.Login(currentUser);
            return null;
        }


        public async Task<bool> Register(User newUser)
        {
            bool ok = _validation.Register(newUser);
            if (ok)
                return await _userRepository.AddUser(newUser);
            return false;
        }
        #endregion
    }
}
