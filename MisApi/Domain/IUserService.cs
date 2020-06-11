using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisApi.Domain
{
    public interface IUserService
    {
        string GetToken(int id);
    }
}
