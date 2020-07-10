using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerCoreLibrary.API;
using Shared.Model;


namespace ServerCoreLibrary.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody]User currentUser)
        {
            return await _userService.Login(currentUser);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register(User newUser)
        {
            if (ModelState.IsValid)
                return await _userService.Register(newUser);
            return false;
        }



    }
}
