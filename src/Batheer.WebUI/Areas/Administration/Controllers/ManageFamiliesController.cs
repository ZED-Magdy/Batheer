using Batheer.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Families.Queries.GetByObjectkey;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    public class ManageFamiliesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;



        public ManageFamiliesController(ApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }



        public async Task<IActionResult> Details(Guid familyObjectkey)
        {
            var model = await Mediator.Send(new GetByObjectkeyQuery(familyObjectkey));

            return View(model);
        }

    }
}
