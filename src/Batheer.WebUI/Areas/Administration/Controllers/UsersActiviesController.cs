using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]

    public class UsersActiviesController : BaseController
    {
        public IActionResult Logins()
        {
            return View();
        }
       
    }
}
