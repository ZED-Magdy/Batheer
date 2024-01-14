using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetTargetedSchedulingForProjectImplementations = Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetTargetedSchedulingForProjectImplementations;
using Batheer.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Batheer.Domain;
using Microsoft.AspNetCore.Authorization;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    public class TargetedSchedulingForProjectImplementationsController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public TargetedSchedulingForProjectImplementationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administration/TargetedSchedulingForProjectImplementations
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetTargetedSchedulingForProjectImplementations.GetTargetedSchedulingForProjectImplementationsQuery());
            return View(model);

            

            //var applicationDBContext = _context.TargetedSchedulingForProjectImplementations
            //    .Include(t => t.AssociationAffiliatedProject.CouncilProject)
            //    .Include(t => t.TargetedSchedulingForProjectImplementationStatus);
            //return View(await applicationDBContext.ToListAsync());
        }

        // GET: Administration/TargetedSchedulingForProjectImplementations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetedSchedulingForProjectImplementation = await _context.TargetedSchedulingForProjectImplementations
                .Include(t => t.AssociationAffiliatedProject)
                .Include(t => t.TargetedSchedulingForProjectImplementationStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (targetedSchedulingForProjectImplementation == null)
            {
                return NotFound();
            }

            return View(targetedSchedulingForProjectImplementation);
        }

        // GET: Administration/TargetedSchedulingForProjectImplementations/Create
        public IActionResult Create()
        {
            ViewData["AssociationAffiliatedProjectId"] = new SelectList(_context.AssociationAffiliatedProjects, "Id", "Id");
            ViewData["TargetedSchedulingForProjectImplementationStatusId"] = new SelectList(_context.TargetedSchedulingForProjectImplementationStatuses, "Id", "Id");
            return View();
        }

        // POST: Administration/TargetedSchedulingForProjectImplementations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssociationAffiliatedProjectId,FromDate,ToDate,TargetedSchedulingForProjectImplementationStatusId")] TargetedSchedulingForProjectImplementation targetedSchedulingForProjectImplementation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(targetedSchedulingForProjectImplementation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationAffiliatedProjectId"] = new SelectList(_context.AssociationAffiliatedProjects, "Id", "Id", targetedSchedulingForProjectImplementation.AssociationAffiliatedProjectId);
            ViewData["TargetedSchedulingForProjectImplementationStatusId"] = new SelectList(_context.TargetedSchedulingForProjectImplementationStatuses, "Id", "Id", targetedSchedulingForProjectImplementation.TargetedSchedulingForProjectImplementationStatusId);
            return View(targetedSchedulingForProjectImplementation);
        }

        // GET: Administration/TargetedSchedulingForProjectImplementations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetedSchedulingForProjectImplementation = await _context.TargetedSchedulingForProjectImplementations.FindAsync(id);
            if (targetedSchedulingForProjectImplementation == null)
            {
                return NotFound();
            }
            ViewData["AssociationAffiliatedProjectId"] = new SelectList(_context.AssociationAffiliatedProjects, "Id", "Id", targetedSchedulingForProjectImplementation.AssociationAffiliatedProjectId);
            ViewData["TargetedSchedulingForProjectImplementationStatusId"] = new SelectList(_context.TargetedSchedulingForProjectImplementationStatuses, "Id", "Id", targetedSchedulingForProjectImplementation.TargetedSchedulingForProjectImplementationStatusId);
            return View(targetedSchedulingForProjectImplementation);
        }

        // POST: Administration/TargetedSchedulingForProjectImplementations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssociationAffiliatedProjectId,FromDate,ToDate,TargetedSchedulingForProjectImplementationStatusId")] TargetedSchedulingForProjectImplementation targetedSchedulingForProjectImplementation)
        {
            if (id != targetedSchedulingForProjectImplementation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(targetedSchedulingForProjectImplementation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TargetedSchedulingForProjectImplementationExists(targetedSchedulingForProjectImplementation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationAffiliatedProjectId"] = new SelectList(_context.AssociationAffiliatedProjects, "Id", "Id", targetedSchedulingForProjectImplementation.AssociationAffiliatedProjectId);
            ViewData["TargetedSchedulingForProjectImplementationStatusId"] = new SelectList(_context.TargetedSchedulingForProjectImplementationStatuses, "Id", "Id", targetedSchedulingForProjectImplementation.TargetedSchedulingForProjectImplementationStatusId);
            return View(targetedSchedulingForProjectImplementation);
        }

        // GET: Administration/TargetedSchedulingForProjectImplementations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetedSchedulingForProjectImplementation = await _context.TargetedSchedulingForProjectImplementations
                .Include(t => t.AssociationAffiliatedProject)
                .Include(t => t.TargetedSchedulingForProjectImplementationStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (targetedSchedulingForProjectImplementation == null)
            {
                return NotFound();
            }

            return View(targetedSchedulingForProjectImplementation);
        }

        // POST: Administration/TargetedSchedulingForProjectImplementations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var targetedSchedulingForProjectImplementation = await _context.TargetedSchedulingForProjectImplementations.FindAsync(id);
            _context.TargetedSchedulingForProjectImplementations.Remove(targetedSchedulingForProjectImplementation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TargetedSchedulingForProjectImplementationExists(int id)
        {
            return _context.TargetedSchedulingForProjectImplementations.Any(e => e.Id == id);
        }
    }
}
