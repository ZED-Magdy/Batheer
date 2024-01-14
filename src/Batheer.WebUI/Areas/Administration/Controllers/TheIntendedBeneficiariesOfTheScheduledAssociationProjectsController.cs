using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Batheer.Domain;
using Batheer.Infrastructure.Persistence;
using GetTheIntendedBeneficiaries = Batheer.Application.TheIntendedBeneficiaries.Queries.GetTheIntendedBeneficiaries;
using Microsoft.AspNetCore.Authorization;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    public class TheIntendedBeneficiariesOfTheScheduledAssociationProjectsController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public TheIntendedBeneficiariesOfTheScheduledAssociationProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administration/TheIntendedBeneficiariesOfTheScheduledAssociationProjects
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetTheIntendedBeneficiaries.GetTheIntendedBeneficiariesOfTheScheduledAssociationProjectsQuery());
            return View(model);

            //var applicationDBContext = _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects
            //    .Include(t => t.TargetedSchedulingForProjectImplementation);
            //return View(await applicationDBContext.ToListAsync());
        }

        // GET: Administration/TheIntendedBeneficiariesOfTheScheduledAssociationProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theIntendedBeneficiariesOfTheScheduledAssociationProject = await _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                .Include(t => t.TargetedSchedulingForProjectImplementation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (theIntendedBeneficiariesOfTheScheduledAssociationProject == null)
            {
                return NotFound();
            }

            return View(theIntendedBeneficiariesOfTheScheduledAssociationProject);
        }

        // GET: Administration/TheIntendedBeneficiariesOfTheScheduledAssociationProjects/Create
        public IActionResult Create()
        {
            ViewData["TargetedSchedulingForProjectImplementationId"] = new SelectList(_context.TargetedSchedulingForProjectImplementations, "Id", "Id");
            return View();
        }

        // POST: Administration/TheIntendedBeneficiariesOfTheScheduledAssociationProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TargetedSchedulingForProjectImplementationId,BaseRequestId,IsDeleted,IsDeletedDate,IsDeletedBy")] TheIntendedBeneficiariesOfTheScheduledAssociationProject theIntendedBeneficiariesOfTheScheduledAssociationProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theIntendedBeneficiariesOfTheScheduledAssociationProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TargetedSchedulingForProjectImplementationId"] = new SelectList(_context.TargetedSchedulingForProjectImplementations, "Id", "Id", theIntendedBeneficiariesOfTheScheduledAssociationProject.TargetedSchedulingForProjectImplementationId);
            return View(theIntendedBeneficiariesOfTheScheduledAssociationProject);
        }

        // GET: Administration/TheIntendedBeneficiariesOfTheScheduledAssociationProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theIntendedBeneficiariesOfTheScheduledAssociationProject = await _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects.FindAsync(id);
            if (theIntendedBeneficiariesOfTheScheduledAssociationProject == null)
            {
                return NotFound();
            }
            ViewData["TargetedSchedulingForProjectImplementationId"] = new SelectList(_context.TargetedSchedulingForProjectImplementations, "Id", "Id", theIntendedBeneficiariesOfTheScheduledAssociationProject.TargetedSchedulingForProjectImplementationId);
            return View(theIntendedBeneficiariesOfTheScheduledAssociationProject);
        }

        // POST: Administration/TheIntendedBeneficiariesOfTheScheduledAssociationProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TargetedSchedulingForProjectImplementationId,BaseRequestId,IsDeleted,IsDeletedDate,IsDeletedBy")] TheIntendedBeneficiariesOfTheScheduledAssociationProject theIntendedBeneficiariesOfTheScheduledAssociationProject)
        {
            if (id != theIntendedBeneficiariesOfTheScheduledAssociationProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theIntendedBeneficiariesOfTheScheduledAssociationProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheIntendedBeneficiariesOfTheScheduledAssociationProjectExists(theIntendedBeneficiariesOfTheScheduledAssociationProject.Id))
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
            ViewData["TargetedSchedulingForProjectImplementationId"] = new SelectList(_context.TargetedSchedulingForProjectImplementations, "Id", "Id", theIntendedBeneficiariesOfTheScheduledAssociationProject.TargetedSchedulingForProjectImplementationId);
            return View(theIntendedBeneficiariesOfTheScheduledAssociationProject);
        }

        // GET: Administration/TheIntendedBeneficiariesOfTheScheduledAssociationProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theIntendedBeneficiariesOfTheScheduledAssociationProject = await _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                .Include(t => t.TargetedSchedulingForProjectImplementation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (theIntendedBeneficiariesOfTheScheduledAssociationProject == null)
            {
                return NotFound();
            }

            return View(theIntendedBeneficiariesOfTheScheduledAssociationProject);
        }

        // POST: Administration/TheIntendedBeneficiariesOfTheScheduledAssociationProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theIntendedBeneficiariesOfTheScheduledAssociationProject = await _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects.FindAsync(id);
            _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects.Remove(theIntendedBeneficiariesOfTheScheduledAssociationProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheIntendedBeneficiariesOfTheScheduledAssociationProjectExists(int id)
        {
            return _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects.Any(e => e.Id == id);
        }
    }
}
