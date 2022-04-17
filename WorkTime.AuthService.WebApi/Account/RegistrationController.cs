using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTime.AuthService.WebApi.Account
{
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        [HttpGet("[action]")]
        [Authorize]
        //[Authorize(Roles = "Administrator")]
        public IActionResult GetAll()
        {
            return Ok("получилось");
        }

    }
}
