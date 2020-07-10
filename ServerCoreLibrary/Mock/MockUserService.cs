using BusinessLogic.UserValidation;
using ServerCoreLibrary.API;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Mock
{
    public class MockUserService : IUserService
    {
        public IEnumerable<User> Users { get; set; }
        private readonly UserValidation _validation;

        public MockUserService()
        {
            Users = new List<User>
            {
                new User{UserName="baroved",Password="12345",IsAdmin=true},
                new User{UserName="bar",Password="12345"}
            };
           _validation = new UserValidation();
        }
        public Task<User> Login(User currentUser)
        {
            bool ok = _validation.Login(currentUser);
            if (ok)
            {
                var check = Users.Where(user => user.UserName == currentUser.UserName &&
                  user.Password == currentUser.Password).FirstOrDefault();
                return Task.FromResult(check);
            }
            else
                return null;
        }
        
        public Task<bool> Register(User newUser)
        {
            bool ok = _validation.Register(newUser);
            if (ok)
            {
                if (!IsExists(newUser.UserName))
                {
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            else
                return Task.FromResult(false);
        }

        public bool IsExists(string userName)
        {
            var checkExists = Users.Where(user => user.UserName == userName).FirstOrDefault();
            if (checkExists != null)
                return true;
            return false;
        }
    }
}
