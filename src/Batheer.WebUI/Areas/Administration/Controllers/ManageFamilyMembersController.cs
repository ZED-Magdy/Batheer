using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.FamilyMembers.Queries.GetFamilyMemberByObjectkey;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    public class ManageFamilyMembersController : BaseController
    {
        private readonly ICurrentUserService _currentUserService;

        public ManageFamilyMembersController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> Details(Guid memberObjectkey)
        {
            var model = await Mediator.Send(new GetFamilyMemberByObjectkeyQuery(memberObjectkey));

            return View(model);
        }






    }
}
