using BusinessLogic.InputValidation;
using BusinessLogic.UserValidation;
using ServerCoreLibrary.API;
using ServerCoreLibrary.Mock;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTesting
{
    public class UserTesting
    {
        #region Properties
        private readonly IUserService _userService = new MockUserService();
        #endregion

        #region MethodsTesting
        [Fact]
        public async void Login()
        {
            User user = new User()
            {
                UserName = "baroved",
                Password = "12345"
            };

            User userLogin = await _userService.Login(user);
            Assert.NotNull(userLogin);

        }

        [Fact]
        public async void LoginError()
        {
            User user = new User()
            {
                UserName = "baroved",
                Password = "kjljl"
            };

            User userLogin = await _userService.Login(user);
            Assert.Null(userLogin);

        }


        [Fact]
        public async void RegisterError()
        {
            User user = new User()
            {
                UserName = "baroved",
                Password = "kjljl"
            };

            bool userRegister = await _userService.Register(user);
            Assert.False(userRegister);

        }

        [Fact]
        public async void Register()
        {
            User user = new User()
            {
                UserName = "b",
                Password = "111"
            };

            bool userRegister = await _userService.Register(user);
            Assert.True(userRegister);

        }
        #endregion
    }
}
