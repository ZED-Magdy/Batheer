using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Batheer.Domain;
using Batheer.Infrastructure.Persistence;
using GetAssociationAffiliatedProjects= Batheer.Application.AssociationAffiliatedProjects.Queries.GetAssociationAffiliatedProjects;
using Microsoft.AspNetCore.Authorization;
using Batheer.Application.TheIntendedBeneficiaries.Queries.GetAssignedByTargetedSchedulingForProjectImplementationId;
using Batheer.Application.TheIntendedBeneficiaries.Queries.GetUnAssignedByTargetedSchedulingForProjectImplementationId;
using Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetById;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    public class AssociationAffiliatedProjectsController : BaseController
    {

        public AssociationAffiliatedProjectsController()
        {
        }

        // GET: Administration/AssociationAffiliatedProjects
        public async Task<IActionResult> Index()
        {
            
            var model = await Mediator.Send(new GetAssociationAffiliatedProjects.GetAssociationAffiliatedProjectsQuery());
            return View(model);
        }

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

    }
}
