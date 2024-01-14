using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Batheer.Domain;
using Batheer.Infrastructure.Persistence;
using GetAssociationAffiliatedProjects = Batheer.Application.AssociationAffiliatedProjects.Queries.GetByAssociationsAffiliatedId;
using Batheer.Application.CouncilProjects.Queries.GetCouncilProjects;
using Batheer.Application.AssociationAffiliatedProjects.Commands.CreateAssociationAffiliatedProject;
using Batheer.Application.AssociationAffiliatedProjects.Queries.GetById;
using Batheer.Application.AssociationAffiliatedProjects.Commands.UpdateAssociationAffiliatedProject;
using Batheer.Application.AssociationAffiliatedProjects.Commands.DeleteAssociationAffiliatedProject;
using Microsoft.AspNetCore.Authorization;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Modules.Lookups.Queries.GetFamilyNeedsWithDetails;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]
    public class AssociationAffiliatedProjectsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public AssociationAffiliatedProjectsController(ApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        // GET: Administration/AssociationAffiliatedProjects
        public async Task<IActionResult> Index()
        {

            var model = await Mediator.Send(new GetAssociationAffiliatedProjects.GetByAssociationsAffiliatedIdQuery(_currentUserService.CouncilId));
            return View(model);
        }

        // GET: Administration/AssociationAffiliatedProjects/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CouncilProjectId"] = new SelectList(await Mediator.Send(new GetCouncilProjectsQuery()), "Id", "Name");
            ViewBag.FamilyNeeds = await Mediator.Send(new GetFamilyNeedsWithDetailsQuery());

            return View();
        }

        // POST: Administration/AssociationAffiliatedProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAssociationAffiliatedProjectCommand command)
        {
            if (ModelState.IsValid)
            {
                command.AssociationsAffiliatedWithTheCouncilId = _currentUserService.CouncilId;
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CouncilProjectId"] = new SelectList(await Mediator.Send(new GetCouncilProjectsQuery()), "Id", "Name");
            ViewBag.FamilyNeeds = await Mediator.Send(new GetFamilyNeedsWithDetailsQuery());

            return View(command);
        }

        // GET: Administration/AssociationAffiliatedProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationAffiliatedProject = await Mediator.Send(new GetByIdQuery(id.Value));
            if (associationAffiliatedProject == null)
            {
                return NotFound();
            }
            ViewData["CouncilProjectId"] = new SelectList(await Mediator.Send(new GetCouncilProjectsQuery()), "Id", "Name");
            ViewBag.FamilyNeeds = await Mediator.Send(new GetFamilyNeedsWithDetailsQuery());

            return View(associationAffiliatedProject);
        }

        // POST: Administration/AssociationAffiliatedProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateAssociationAffiliatedProjectCommand command)
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

            ViewData["CouncilProjectId"] = new SelectList(await Mediator.Send(new GetCouncilProjectsQuery()), "Id", "Name");
            ViewBag.FamilyNeeds = await Mediator.Send(new GetFamilyNeedsWithDetailsQuery());
            var associationAffiliatedProject = await Mediator.Send(new GetByIdQuery(command.Id));

            return View(associationAffiliatedProject);
        }

        // GET: Administration/AssociationAffiliatedProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationAffiliatedProject = await Mediator.Send(new GetByIdQuery(id.Value));
            if (associationAffiliatedProject == null)
            {
                return NotFound();
            }

            return View(associationAffiliatedProject);
        }

        // POST: Administration/AssociationAffiliatedProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DeleteAssociationAffiliatedProjectCommand command)
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
