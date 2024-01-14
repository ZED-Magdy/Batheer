using Batheer.Application.ExcludeIdentityNumbers.Commands.CreateExcludeIdentityNumber;
using Batheer.Application.ExcludeIdentityNumbers.Commands.DeleteExcludeIdentityNumber;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    public class ManageExcludeIdentityNumbersController : BaseController
    {
        public async Task<IActionResult> Index(string Search_identityNo, int? Search_associationsAffiliatedWithTheCouncilId)
        {
            ViewBag.Search_AssociationsAffiliatedWithTheCouncilId = Search_associationsAffiliatedWithTheCouncilId;
            ViewBag.Search_IdentityNo = Search_identityNo;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExcludeIdentityNumberCommand command)
        {
            var model = await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteExcludeIdentityNumberCommand command)
        {
            var model = await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
