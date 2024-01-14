using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Batheer.WebUI.Areas.Researcher.Controllers
{
    [Area("Researcher")]
    [Authorize(Roles = "Researcher")]

    public class VisitingResultsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
