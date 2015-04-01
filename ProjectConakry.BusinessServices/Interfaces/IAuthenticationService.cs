using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectConakry.DomainObjects;

namespace ProjectConakry.BusinessServices
{
    public interface IAuthenticationService
    {
        bool Authenticate(string UserName, string Password, bool IsAdmin = false);
    }
}
