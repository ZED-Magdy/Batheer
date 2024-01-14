using Batheer.Application.Modules.UserAccess.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Interfaces
{
    public interface IJwtToken
    {
        string Generate(string username);
        string Generate(AuthenticateResponse response);
    }
}
