using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
