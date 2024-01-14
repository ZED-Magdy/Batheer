using Microsoft.AspNetCore.Authorization;
using Batheer.Application.FamilyMembers.Commands.CreateFamilyMember;
using Batheer.Application.FamilyMembers.Queries.GetFamilyMemberById;
using Batheer.Application.Modules.Lookups.Queries.GetEducationalLevels;
using Batheer.Application.Modules.Lookups.Queries.GetGenders;
using Batheer.Application.Modules.Lookups.Queries.GetHealthStatuses;
using Batheer.Application.Modules.Lookups.Queries.GetNationalities;
using Batheer.Application.ResponsibleFamilyMembers.Queries.GetByFamilyId;
using Batheer.Application.ResponsibleFamilyMembers.Queries.GetByFamilyRegistrationRequestId;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batheer.Application.Requests.PersonalDataForms.Queries.GetCanCreateStatusForIdentityNo;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.ResponsibleFamilyMembers.Queries.GetByFamilyObjectkey;
using Batheer.Application.FamilyMembers.Queries.GetFamilyMemberByObjectkey;
using Batheer.Application.FamilyMembers.Commands.DeleteFamilyMember;
using Batheer.Application.Requests.PersonalDataForms.Queries.GetPersonInfoByIdentityNo;
using Batheer.Application.FamilyMembers.Commands.UpdateFamilyMember;
using AutoMapper;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]
    public class ManageFamilyMembersController : BaseController
    {
        private readonly ICurrentUserService _currentUserService;

        public ManageFamilyMembersController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> Index(Guid familyObjectkey)
        {
            ViewBag.FamilyRegistrationRequest = await Mediator.Send(new GetByFamilyObjectkeyQuery(familyObjectkey));


            var model = await Mediator.Send(new Batheer.Application.FamilyMembers.Queries.GetByFamilyObjectkey
                .GetByFamilyObjectkeyQuery(familyObjectkey));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SearchForCreate(int familyId, Guid familyObjectkey)
        {
            ViewBag.FamilyId = familyId;
            ViewBag.FamilyObjectkey = familyObjectkey;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchForCreate(int familyId, Guid familyObjectkey, GetCanCreateStatusForIdentityNoQuery query)
        {

            ViewBag.FamilyId = familyId;
            ViewBag.FamilyObjectkey = familyObjectkey;

            if (ModelState.IsValid)
            {
                query.AssociationsAffiliatedId = _currentUserService.CouncilId;
                var result = await Mediator.Send(query);

                var personInfoByIdentityNo = await Mediator.Send(new GetPersonInfoByIdentityNoQuery(query.IdentityNo));

                switch (result.Status)
                {
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoNotUsedYet:
                        return RedirectToAction(nameof(Create), new { familyId = familyId, identityNo = query.IdentityNo, familyObjectkey = familyObjectkey });
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.RequestExistBefore:
                        ModelState.AddModelError("", "سبق أن تم إضافة هذا الرقم");
                        ModelState.AddModelError("", $"{personInfoByIdentityNo.FullName } - {personInfoByIdentityNo.IdentityNo} - {personInfoByIdentityNo.MemberOrResponsibleInFamily} - {personInfoByIdentityNo.AssociationsAffiliatedWithTheCouncilName}");
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoUsedInAnotherAffiliated:
                        ModelState.AddModelError("", "سبق استخدام هذه الهوية في جمعية/جهة أخرى في المجلس");
                        ModelState.AddModelError("", $"{personInfoByIdentityNo.FullName } - {personInfoByIdentityNo.IdentityNo} - {personInfoByIdentityNo.MemberOrResponsibleInFamily} - {personInfoByIdentityNo.AssociationsAffiliatedWithTheCouncilName}");
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.ExistIn_PersonalDataForm:
                        ModelState.AddModelError("", "سبق استخدام هذه الهوية في المجلس");
                        ModelState.AddModelError("", $"{personInfoByIdentityNo.FullName } - {personInfoByIdentityNo.IdentityNo} - {personInfoByIdentityNo.MemberOrResponsibleInFamily} - {personInfoByIdentityNo.AssociationsAffiliatedWithTheCouncilName}");
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.ExistIn_ExcludeIdentityNumbers:
                        ModelState.AddModelError("", "رقم الهوية ضمن قائمة الهويات المستبعدة من المجلس");
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoDeleted:
                        ModelState.AddModelError("", "رقم الهوية سبق أن تم حذفه");
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.AllowToCreate:
                        return RedirectToAction(nameof(Create), new { familyId = familyId, identityNo = query.IdentityNo, familyObjectkey = familyObjectkey });
                        break;
                    default:
                        break;
                }
            }
            return View();
        }


        public async Task<IActionResult> Create(int familyId, string identityNo, string familyObjectkey)
        {
            ViewBag.FamilyId = familyId;
            ViewBag.IdentityNo = identityNo;
            ViewBag.FamilyObjectkey = familyObjectkey;

            await Create_fillData();
            return View();
        }

        // POST: Administration/TargetedSchedulingForProjectImplementations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFamilyMemberCommand command, Guid familyObjectkey)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index), new { familyObjectkey });
            }

            ViewBag.FamilyId = command.FamilyId;
            ViewBag.IdentityNo = command.PersonalDataForm.IdentityNo;
            ViewBag.FamilyObjectkey = familyObjectkey;

            await Create_fillData();
            return View(command);
        }

        public async Task<IActionResult> Details(Guid memberObjectkey)
        {
            var model = await Mediator.Send(new GetFamilyMemberByObjectkeyQuery(memberObjectkey));

            return View(model);
        }

        public async Task<IActionResult> Delete(Guid memberObjectkey)
        {
            ViewBag.memberObjectkey = memberObjectkey;
            var model = await Mediator.Send(new GetFamilyMemberByObjectkeyQuery(memberObjectkey));

            ViewBag.familyObjectkey = model.FamilyObjectkey;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(DeleteFamilyMemberCommand command, Guid memberObjectkey, Guid familyObjectkey)
        {
            var model = await Mediator.Send(command);

            return RedirectToAction(nameof(Index), new { familyObjectkey = familyObjectkey });
        }

        private async Task Create_fillData()
        {
            ViewBag.EducationalLevelId = await Mediator.Send(new GetEducationalLevelsQuery());
            ViewBag.HealthStatusId = await Mediator.Send(new GetHealthStatusesQuery());
            ViewBag.NationalityId = await Mediator.Send(new GetNationalitiesQuery());
            ViewBag.GenderId = await Mediator.Send(new GetGendersQuery());

        }


        public async Task<IActionResult> Edit(Guid memberObjectkey)
        {
            var item = await Mediator.Send(new GetFamilyMemberByObjectkeyQuery(memberObjectkey));
            ViewBag.Item = item;

            await Create_fillData();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Batheer.Application.FamilyMembers.Queries.GetFamilyMemberByObjectkey.FamilyMemberDto, UpdateFamilyMemberCommand>());
            var mapper = new Mapper(config);
            var command = mapper.Map<UpdateFamilyMemberCommand>(item);

            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateFamilyMemberCommand command, Guid familyObjectkey)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index), new { familyObjectkey });
            }

            ViewBag.FamilyObjectkey = familyObjectkey;

            var item = await Mediator.Send(new GetFamilyMemberByObjectkeyQuery(command.Objectkey));
            ViewBag.Item = item;

            await Create_fillData();
            return View(command);
        }
    }
}
