using Batheer.Application.Modules.Lookups.Commands.FamilyNeedDetails.CreateFamilyNeedDetail;
using Batheer.Application.Modules.Lookups.Queries.GetFamilyNeeds;
using Batheer.Application.Modules.Lookups.Queries.GetFamilyNeedsWithDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    public class ManageFamilyNeedsController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetFamilyNeedsWithDetailsQuery());
            return View(model);
        }

        public async Task<IActionResult> CreateDetails()
        {
            ViewBag.FamilyNeeds = await Mediator.Send(new GetFamilyNeedsQuery());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetails(CreateFamilyNeedDetailCommand command)
        {
            var model = await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
