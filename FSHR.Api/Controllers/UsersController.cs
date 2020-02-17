using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSHR.Services;
using Microsoft.AspNetCore.Mvc;

namespace FSHR.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public Task Post(Services.DTOs.UserRegisterDto data)
        {
            return _userService.Register(data);
        }
    }
}
