using Batheer.Application.ExcludeIdentityNumbers.Commands.CreateExcludeIdentityNumber;
using Batheer.Application.ExcludeIdentityNumbers.Commands.DeleteExcludeIdentityNumber;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]
    public class ExcludeIdentityNumbersController : BaseController
    {
        public async Task<IActionResult> Index(string Search_identityNo)
        {
            ViewBag.Search_IdentityNo = Search_identityNo;

            return View();
        }
    }
}
