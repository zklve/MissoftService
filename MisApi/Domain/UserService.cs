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
            return id.ToString();
        }
    }
}
