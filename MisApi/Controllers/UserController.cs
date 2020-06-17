using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiRregConsulApi.Domain;

namespace MiRregConsulApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public IUserService userService;
        public ILogger _logger;

        public UserController(IUserService service)
        {
            userService = service;
            //_logger = logger;
        }


        public string GetUserToken(int id)
        {
            //_logger.LogDebug(id.ToString());
            return userService.GetToken(id);
        }

        public string HealthCheck()
        {
            //_logger.LogDebug(id.ToString());
            return "111";
        }
    }
}