using Microsoft.AspNetCore.Authorization;
using Batheer.Application.DeliveryAids.Commands.DeliverAid;
using Batheer.Application.DeliveryAids.Queries.SearchByReceivedCode;
using Batheer.WebUI.Areas.AssociationsAffiliated.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batheer.Application.Common.Interfaces;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]
    public class DeliveryAidsController : BaseController
    {
        private readonly ICurrentUserService _currentUserService;

        public DeliveryAidsController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> Index(SearchByReceivedCodeQuery query)
        {

            if (ModelState.IsValid)
            {
                if (query.FamilyId > 0)
                {

                    var queryResult = await Mediator.Send(query);

                    ViewBag.QueryResult = queryResult;
                    ViewBag.EmptyMessage = queryResult == null ? "لا يوجد نتيجة" : null;
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeliverAid(DeliverAidCommand command)
        {
            command.AssociationAffiliatedId = _currentUserService.CouncilId;
            await Mediator.Send(command);

            if (ModelState.IsValid)
            {

            }

            return RedirectToAction(nameof(Index), new { command.AssociationAffiliatedId, command.FamilyId, command.TheIntendedBeneficiariesOfTheScheduledAssociationProjectId });
        }

    }
}
