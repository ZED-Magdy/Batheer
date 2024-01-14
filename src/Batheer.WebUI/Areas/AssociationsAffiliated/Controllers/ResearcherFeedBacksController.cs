using Batheer.Application.Users.Commands.CreateUser;
using Batheer.Application.Users.Queries.GetUsersByRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Threading.Tasks;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]
    public class ResearcherFeedBacksController : BaseController
    {
        public async Task<IActionResult> VisitingResults(string identityNo)
        {

            ViewBag.IdentityNo = identityNo;

            return View();
        }


    }
}
