using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAuthApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult(new { name="张三" });
        }

        [Authorize]
        [HttpGet]
        public IActionResult IndexA()
        {
            return new JsonResult(new { name = "张三" });
        }
    }
}