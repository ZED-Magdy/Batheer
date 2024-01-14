using Microsoft.AspNetCore.Authorization;
using Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetById;
using Batheer.Application.TheIntendedBeneficiaries.Commands.AssignRequest;
using Batheer.Application.TheIntendedBeneficiaries.Commands.UnAssignRequest;
using Batheer.Application.TheIntendedBeneficiaries.Queries.GetAssignedByTargetedSchedulingForProjectImplementationId;
using Batheer.Application.TheIntendedBeneficiaries.Queries.GetUnAssignedByTargetedSchedulingForProjectImplementationId;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batheer.Application.TargetedSchedulingForProjectImplementations.Commands.ApproveTargetedSchedulingForProjectImplementation;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]
    public class TheIntendedBeneficiariesController : BaseController
    {
        public async Task<IActionResult> ManageBeneficiaries(int? targetedSchedulingForProjectImplementationId)
        {
            if (targetedSchedulingForProjectImplementationId is null)
            {
                throw new ArgumentNullException(nameof(targetedSchedulingForProjectImplementationId));
            }

            if (targetedSchedulingForProjectImplementationId == null)
            {
                return NotFound();
            }

            var TargetedSchedulingForProjectImplementation = await Mediator.Send(new GetByIdQuery(targetedSchedulingForProjectImplementationId.Value));
            if (TargetedSchedulingForProjectImplementation == null)
            {
                return NotFound();
            }

            ViewBag.Assigned = await Mediator.Send(new GetAssignedByTargetedSchedulingForProjectImplementationIdQuery(targetedSchedulingForProjectImplementationId.Value));
            ViewBag.UnAssigned = await Mediator.Send(new GetUnAssignedByTargetedSchedulingForProjectImplementationIdQuery(targetedSchedulingForProjectImplementationId.Value));


            return View(TargetedSchedulingForProjectImplementation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approved(ApproveTargetedSchedulingForProjectImplementationCommand command)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(ManageBeneficiaries), new { targetedSchedulingForProjectImplementationId = command.TargetedSchedulingForProjectImplementationId });
            }

            // handle error message
            return RedirectToAction(nameof(ManageBeneficiaries), new { targetedSchedulingForProjectImplementationId = command.TargetedSchedulingForProjectImplementationId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRequest(int targetedSchedulingForProjectImplementationId, AssignRequestCommand command)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(ManageBeneficiaries), new { targetedSchedulingForProjectImplementationId = targetedSchedulingForProjectImplementationId });
            }

            // handle error message
            return RedirectToAction(nameof(ManageBeneficiaries), new { targetedSchedulingForProjectImplementationId = targetedSchedulingForProjectImplementationId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnAssignRequest(int targetedSchedulingForProjectImplementationId, UnAssignRequestCommand command)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(ManageBeneficiaries), new { targetedSchedulingForProjectImplementationId = targetedSchedulingForProjectImplementationId });
            }

            // handle error message
            return RedirectToAction(nameof(ManageBeneficiaries), new { targetedSchedulingForProjectImplementationId = targetedSchedulingForProjectImplementationId });
        }
    }
}
