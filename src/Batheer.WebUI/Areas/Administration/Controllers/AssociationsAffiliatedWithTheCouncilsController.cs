using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Batheer.Domain;
using Batheer.Infrastructure.Persistence;
using AssociationsAffiliatedWithTheCouncils = Batheer.Application.AssociationsAffiliatedWithTheCouncils.Queries.GetAssociationsAffiliatedWithTheCouncils;
using Microsoft.AspNetCore.Authorization;
using Batheer.Application.AssociationsAffiliatedWithTheCouncils.Commands.CreateCouncil;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    public class AssociationsAffiliatedWithTheCouncilsController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public AssociationsAffiliatedWithTheCouncilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administration/AssociationsAffiliatedWithTheCouncils
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new AssociationsAffiliatedWithTheCouncils.GetAssociationsAffiliatedWithTheCouncilsQuery());
            return View(model);
        }

        // GET: Administration/AssociationsAffiliatedWithTheCouncils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationsAffiliatedWithTheCouncil = await _context.AssociationsAffiliatedWithTheCouncils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (associationsAffiliatedWithTheCouncil == null)
            {
                return NotFound();
            }

            return View(associationsAffiliatedWithTheCouncil);
        }

        // GET: Administration/AssociationsAffiliatedWithTheCouncils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/AssociationsAffiliatedWithTheCouncils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCouncilCommand command)
        {
            if (ModelState.IsValid)
            {
                var model = await Mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: Administration/AssociationsAffiliatedWithTheCouncils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationsAffiliatedWithTheCouncil = await _context.AssociationsAffiliatedWithTheCouncils.FindAsync(id);
            if (associationsAffiliatedWithTheCouncil == null)
            {
                return NotFound();
            }
            return View(associationsAffiliatedWithTheCouncil);
        }

        // POST: Administration/AssociationsAffiliatedWithTheCouncils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AboutIt,AdministrativeRestructuring,ContactInformation,LocationOnTheMap")] AssociationsAffiliatedWithTheCouncil associationsAffiliatedWithTheCouncil)
        {
            if (id != associationsAffiliatedWithTheCouncil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associationsAffiliatedWithTheCouncil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociationsAffiliatedWithTheCouncilExists(associationsAffiliatedWithTheCouncil.Id))
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
            return View(associationsAffiliatedWithTheCouncil);
        }

        // GET: Administration/AssociationsAffiliatedWithTheCouncils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationsAffiliatedWithTheCouncil = await _context.AssociationsAffiliatedWithTheCouncils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (associationsAffiliatedWithTheCouncil == null)
            {
                return NotFound();
            }

            return View(associationsAffiliatedWithTheCouncil);
        }

        // POST: Administration/AssociationsAffiliatedWithTheCouncils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var associationsAffiliatedWithTheCouncil = await _context.AssociationsAffiliatedWithTheCouncils.FindAsync(id);
            _context.AssociationsAffiliatedWithTheCouncils.Remove(associationsAffiliatedWithTheCouncil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociationsAffiliatedWithTheCouncilExists(int id)
        {
            return _context.AssociationsAffiliatedWithTheCouncils.Any(e => e.Id == id);
        }
    }
}
