using Batheer.Application.Common.Interfaces;
using Batheer.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Data;
using Batheer.Application.AssociationsAffiliatedWithTheCouncilInfos.Queries.GetByObjectkey;
using System.Threading.Tasks;
using Batheer.Application.AssociationAffiliatedProjects.Commands.DeleteAssociationAffiliatedProject;
using Batheer.Application.AssociationsAffiliatedWithTheCouncilInfos.Commands.CreateAssociationsAffiliatedWithTheCouncilInfo;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]

    public class AssociationsAffiliatedWithTheCouncilInfosController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public AssociationsAffiliatedWithTheCouncilInfosController(ApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetByCurrentUserQuery());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SaveAssociationsAffiliatedWithTheCouncilInfoCommand command)
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