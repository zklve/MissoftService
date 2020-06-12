using MisApi.ConfigMapModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisApi.Domain
{
    public class UserService : IUserService
    {
        public string GetToken(int id)
        {
            var consulConfig = ConfigHelper.Get<ConsulConfig>("consul");
            return id.ToString()+ ",端口号:"+ consulConfig.Port;
        }
    }
}
