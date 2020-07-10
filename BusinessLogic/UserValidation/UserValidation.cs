using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.UserValidation
{
    public class UserValidation
    {
        #region Methods
        public bool Login(User user)
        {
            if (user.UserName == "" || user.Password == "")
                return false;
            return true;
        }

        public bool Register(User newUser)
        {
            if (newUser.UserName == "" || newUser.Password == "" || newUser.Email == "")
                return false;
            return true;
        }
        #endregion

    }
}
