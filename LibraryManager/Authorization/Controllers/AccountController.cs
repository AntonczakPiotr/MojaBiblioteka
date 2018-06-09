using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    [EnableCors("AllowAllHeaders")]
    public class AccountController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationModel model)
        {
            return View();
        }
    }
}