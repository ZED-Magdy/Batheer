using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Batheer.Domain;
using Batheer.Infrastructure.Persistence;
using Batheer.Application.CouncilProjects.Queries.GetCouncilProjects;
using Batheer.Application.TargetedSchedulingForProjectImplementations.Commands.CreateTargetedSchedulingForProjectImplementation;
using Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetById;
using Batheer.Application.TargetedSchedulingForProjectImplementations.Commands.UpdateTargetedSchedulingForProjectImplementation;
using Batheer.Application.TargetedSchedulingForProjectImplementations.Commands.DeleteTargetedSchedulingForProjectImplementation;
using Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetByAssociationsAffiliatedId;
using AssociationAffiliatedProjects = Batheer.Application.AssociationAffiliatedProjects.Queries.GetByAssociationsAffiliatedId;
using Batheer.Application.TargetedSchedulingForProjectImplementationStatuses.Queries.GetProjectImplementationStatuses;
using Microsoft.AspNetCore.Authorization;
using Batheer.Application.Common.Interfaces;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]
    public class TargetedSchedulingForProjectImplementationsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;


        public TargetedSchedulingForProjectImplementationsController(ApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        // GET: Administration/TargetedSchedulingForProjectImplementations
        public async Task<IActionResult> Index()
        {

            var model = await Mediator.Send(new GetByAssociationsAffiliatedIdQuery(_currentUserService.CouncilId));
            return View(model);
        }

        // GET: Administration/TargetedSchedulingForProjectImplementations/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AssociationAffiliatedProjectId"] = new SelectList(await Mediator.Send(new AssociationAffiliatedProjects.GetByAssociationsAffiliatedIdQuery(_currentUserService.CouncilId)), "Id", "ProjectName");
            ViewData["TargetedSchedulingForProjectImplementationStatusId"] = new SelectList(await Mediator.Send(new GetTargetedSchedulingForProjectImplementationStatusesQuery()), "Id", "Name");
            return View();
        }

        // POST: Administration/TargetedSchedulingForProjectImplementations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTargetedSchedulingForProjectImplementationCommand command)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationAffiliatedProjectId"] = new SelectList(await Mediator.Send(new AssociationAffiliatedProjects.GetByAssociationsAffiliatedIdQuery(_currentUserService.CouncilId)), "Id", "ProjectName");
            ViewData["TargetedSchedulingForProjectImplementationStatusId"] = new SelectList(await Mediator.Send(new GetTargetedSchedulingForProjectImplementationStatusesQuery()), "Id", "Name");
            return View(command);
        }

        // GET: Administration/TargetedSchedulingForProjectImplementations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TargetedSchedulingForProjectImplementation = await Mediator.Send(new GetByIdQuery(id.Value));
            if (TargetedSchedulingForProjectImplementation == null)
            {
                return NotFound();
            }
            ViewData["AssociationAffiliatedProjectId"] = new SelectList(await Mediator.Send(new AssociationAffiliatedProjects.GetByAssociationsAffiliatedIdQuery(_currentUserService.CouncilId)), "Id", "ProjectName");
            ViewData["TargetedSchedulingForProjectImplementationStatusId"] = new SelectList(await Mediator.Send(new GetTargetedSchedulingForProjectImplementationStatusesQuery()), "Id", "Name");
            return View(TargetedSchedulingForProjectImplementation);
        }

        // POST: Administration/TargetedSchedulingForProjectImplementations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateTargetedSchedulingForProjectImplementationCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            ViewData["AssociationAffiliatedProjectId"] = new SelectList(await Mediator.Send(new AssociationAffiliatedProjects.GetByAssociationsAffiliatedIdQuery(_currentUserService.CouncilId)), "Id", "ProjectName");
            ViewData["TargetedSchedulingForProjectImplementationStatusId"] = new SelectList(await Mediator.Send(new GetTargetedSchedulingForProjectImplementationStatusesQuery()), "Id", "Name");
            return View();
        }

        // GET: Administration/TargetedSchedulingForProjectImplementations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TargetedSchedulingForProjectImplementation = await Mediator.Send(new GetByIdQuery(id.Value));
            if (TargetedSchedulingForProjectImplementation == null)
            {
                return NotFound();
            }

            return View(TargetedSchedulingForProjectImplementation);
        }

        // POST: Administration/TargetedSchedulingForProjectImplementations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DeleteTargetedSchedulingForProjectImplementationCommand command)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

    }
}
