using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Interfaces
{
    public interface IHttpContextService
    {
        Task Logout();
        Task SignIn(IEnumerable<Claim> claims);
    }
}
