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
using Batheer.Application.AssociationsAffiliatedWithTheCouncilInfos.Queries.GetAssociationsAffiliatedWithTheCouncilInfos;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    [Route("[area]/[Controller]")]

    public class AssociationsAffiliatedWithTheCouncilInfosController : BaseController
    {
        private readonly ICurrentUserService _currentUserService;

        public AssociationsAffiliatedWithTheCouncilInfosController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetCitiesWithAssociationsAffiliatedWithTheCouncilInfosQuery());
            return View(model);
        }

        [Route("{objectkey}")]
        public async Task<IActionResult> Details(Guid objectkey)
        {
            ViewBag.Objectkey = objectkey;

            var model = await Mediator.Send(new GetByObjectkeyQuery(objectkey));

            return View(model);
        }
    }
}