using Microsoft.AspNetCore.Authorization;
using Batheer.Application.Modules.Lookups.Queries.GetEstimatedProjectCosts;
using Batheer.Application.Modules.Lookups.Queries.GetFinanceTypes;
using Batheer.Application.Modules.Lookups.Queries.GetLoanTypes;
using Batheer.Application.Modules.Lookups.Queries.GetProducedFamilyProducts;
using Batheer.Application.Modules.Lookups.Queries.GetSupportingFamilyTypes;
using Batheer.Application.SupportingFamilyRequests.Commands.CreateSupportingFamilyRequest;
using Batheer.Application.SupportingFamilyRequests.Queries.GetByFamilyId;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batheer.Application.SupportingFamilyRequests.Queries.GetByFamilyObjectkey;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]
    public class ManageSupportingFamilyRequestsController : BaseController
    {
        public async Task<IActionResult> Create(Guid familyObjectkey)
        {
            ViewBag.FamilyObjectkey = familyObjectkey;

            await Create_fillData();
            return View();
        }

        // POST: Administration/TargetedSchedulingForProjectImplementations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSupportingFamilyRequestCommand command)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(Details), new { command.FamilyObjectkey });
            }

            await Create_fillData();
            return View(command);
        }

        public async Task<IActionResult> Details(Guid familyObjectkey)
        {
            var model = await Mediator.Send(new GetByFamilyObjectkeyQuery(familyObjectkey));

            return View(model);
        }

        private async Task Create_fillData()
        {
            ViewBag.SupportingFamilyTypeId = await Mediator.Send(new GetSupportingFamilyTypesQuery());
            ViewBag.FinanceTypeId = await Mediator.Send(new GetFinanceTypesQuery());
            ViewBag.ProducedFamilyProductId = await Mediator.Send(new GetProducedFamilyProductsQuery());
            ViewBag.LoanTypeId = await Mediator.Send(new GetLoanTypesQuery());
            ViewBag.EstimatedProjectCostId = await Mediator.Send(new GetEstimatedProjectCostsQuery());
        }

    }
}
