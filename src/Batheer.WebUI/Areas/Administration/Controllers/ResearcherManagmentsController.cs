using Batheer.Application.Users.Commands.CreateUser;
using Batheer.Application.Users.Queries.GetUsersByRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Threading.Tasks;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    public class ResearcherManagmentsController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetUsersByRoleQuery(Domain.AuthenticationUsers.User.UserRoles.Researcher));
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            if (ModelState.IsValid)
            {
                var model = await Mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }



        public async Task<IActionResult> VisitingResults(
            string userName, string identityNo, int? associationsAffiliatedWithTheCouncilId)
        {

            ViewBag.AssociationsAffiliatedWithTheCouncilId = associationsAffiliatedWithTheCouncilId;
            ViewBag.UserName = userName;
            ViewBag.IdentityNo = identityNo;

            return View();
        }
    }
}
