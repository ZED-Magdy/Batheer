using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Batheer.Domain;
using Batheer.Infrastructure.Persistence;
using GetAssociationsAffiliatedWithTheCouncilUsers = Batheer.Application.AssociationsAffiliatedWithTheCouncilUsers.Queries.GetAssociationsAffiliatedWithTheCouncilUsers;
using Microsoft.AspNetCore.Authorization;
using Batheer.Application.AssociationsAffiliatedWithTheCouncilUsers.Commands.CreateUser;
using Batheer.Application.Common.Exceptions;
using Batheer.Application.AssociationsAffiliatedWithTheCouncils.Commands.CreateCouncil;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    public class AssociationsAffiliatedWithTheCouncilUsersController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public AssociationsAffiliatedWithTheCouncilUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administration/AssociationsAffiliatedWithTheCouncilUsers
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetAssociationsAffiliatedWithTheCouncilUsers.GetAssociationsAffiliatedWithTheCouncilUsersQuery());
            return View(model);
        }

        // GET: Administration/AssociationsAffiliatedWithTheCouncilUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationsAffiliatedWithTheCouncilUser = await _context.AssociationsAffiliatedWithTheCouncilUsers
                .Include(a => a.AssociationsAffiliatedWithTheCouncil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (associationsAffiliatedWithTheCouncilUser == null)
            {
                return NotFound();
            }

            return View(associationsAffiliatedWithTheCouncilUser);
        }

        // GET: Administration/AssociationsAffiliatedWithTheCouncilUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/AssociationsAffiliatedWithTheCouncilUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Administration/AssociationsAffiliatedWithTheCouncilUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationsAffiliatedWithTheCouncilUser = await _context.AssociationsAffiliatedWithTheCouncilUsers.FindAsync(id);
            if (associationsAffiliatedWithTheCouncilUser == null)
            {
                return NotFound();
            }
            ViewData["AssociationsAffiliatedWithTheCouncilId"] = new SelectList(_context.AssociationsAffiliatedWithTheCouncils, "Id", "Id", associationsAffiliatedWithTheCouncilUser.AssociationsAffiliatedWithTheCouncilId);
            return View(associationsAffiliatedWithTheCouncilUser);
        }

        // POST: Administration/AssociationsAffiliatedWithTheCouncilUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssociationsAffiliatedWithTheCouncilId,FullName,Mobile,UserName,PhotoUrl")] AssociationsAffiliatedWithTheCouncilUser associationsAffiliatedWithTheCouncilUser)
        {
            if (id != associationsAffiliatedWithTheCouncilUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associationsAffiliatedWithTheCouncilUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociationsAffiliatedWithTheCouncilUserExists(associationsAffiliatedWithTheCouncilUser.Id))
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
            ViewData["AssociationsAffiliatedWithTheCouncilId"] = new SelectList(_context.AssociationsAffiliatedWithTheCouncils, "Id", "Id", associationsAffiliatedWithTheCouncilUser.AssociationsAffiliatedWithTheCouncilId);
            return View(associationsAffiliatedWithTheCouncilUser);
        }

        // GET: Administration/AssociationsAffiliatedWithTheCouncilUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationsAffiliatedWithTheCouncilUser = await _context.AssociationsAffiliatedWithTheCouncilUsers
                .Include(a => a.AssociationsAffiliatedWithTheCouncil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (associationsAffiliatedWithTheCouncilUser == null)
            {
                return NotFound();
            }

            return View(associationsAffiliatedWithTheCouncilUser);
        }

        // POST: Administration/AssociationsAffiliatedWithTheCouncilUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var associationsAffiliatedWithTheCouncilUser = await _context.AssociationsAffiliatedWithTheCouncilUsers.FindAsync(id);
            _context.AssociationsAffiliatedWithTheCouncilUsers.Remove(associationsAffiliatedWithTheCouncilUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociationsAffiliatedWithTheCouncilUserExists(int id)
        {
            return _context.AssociationsAffiliatedWithTheCouncilUsers.Any(e => e.Id == id);
        }
    }
}
