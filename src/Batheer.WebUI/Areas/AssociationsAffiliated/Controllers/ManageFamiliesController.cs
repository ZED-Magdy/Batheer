using Batheer.Application.AssociationAffiliatedProjects.Queries.GetByAssociationsAffiliatedId;
using Batheer.Application.AssociationAffiliatedProjects.Queries.GetByAssociationsAffiliatedIdAndcouncilProjectId;
using Batheer.Application.CouncilProjects.Queries.GetCouncilProjectById;
using Batheer.Application.CouncilProjects.Queries.GetCouncilProjects;
using Batheer.Application.Modules.Lookups.Queries.GetAccommodationTypes;
using Batheer.Application.Modules.Lookups.Queries.GetEducationalLevels;
using Batheer.Application.Modules.Lookups.Queries.GetEstimatedProjectCosts;
using Batheer.Application.Modules.Lookups.Queries.GetFamilyCategories;
using Batheer.Application.Modules.Lookups.Queries.GetFamilyNeeds;
using Batheer.Application.Modules.Lookups.Queries.GetFinanceTypes;
using Batheer.Application.Modules.Lookups.Queries.GetHealthStatuses;
using Batheer.Application.Modules.Lookups.Queries.GetLoanTypes;
using Batheer.Application.Modules.Lookups.Queries.GetMaritalStatuses;
using Batheer.Application.Modules.Lookups.Queries.GetMonthlyIncomes;
using Batheer.Application.Modules.Lookups.Queries.GetNationalities;
using Batheer.Application.Modules.Lookups.Queries.GetOccupations;
using Batheer.Application.Modules.Lookups.Queries.GetProducedFamilyProducts;
using Batheer.Application.Families.Commands.CreateFamily;
using Batheer.Application.Requests.BaseRequests.Queries.GetBaseRequestsForAssociationsAffiliatedWithTheCouncil;
using Batheer.Application.Requests.PersonalDataForms.Queries.GetByBaseRequestId;
using Batheer.Application.Requests.PersonalDataForms.Queries.GetCanCreateStatusForIdentityNo;
using Batheer.Application.Requests.PersonalDataForms.Queries.IsExistsIdentityNo;
using Batheer.Application.Requests.PersonalDataForms.Queries.IsExistsIdentityNoAndAssociationsAffiliatedId;
using Batheer.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batheer.Application.Modules.Lookups.Queries.GetGenders;
using Batheer.Application.Requests.BaseRequests.Queries.GetFamiliesByCouncilId;
using Batheer.Application.Families.Queries.GetById;
using Microsoft.AspNetCore.Authorization;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Models;
using Batheer.Application.Reports.Queries.ExportFamilyRegistrationRequests;
using Batheer.Application.Reports.Queries.ExportFamilyMembers;
using Batheer.Application.Reports.Queries.ExportSupportingFamilyRequests;
using Batheer.Application.Families.Queries.GetByObjectkey;
using Batheer.Application.Families.Commands.DeleteFamily;
using Batheer.Application.Requests.BaseRequests.Queries.SearchInFamilyRegistrationRequests;
using Batheer.Application.Common.Exceptions;
using Batheer.Application.Requests.PersonalDataForms.Queries.GetPersonInfoByIdentityNo;
using Batheer.Application.Families.Commands.UpdateFamily;
using AutoMapper;

namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
{
    [Area("AssociationsAffiliated")]
    [Authorize(Roles = "CouncilRole")]
    public class ManageFamiliesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;



        public ManageFamiliesController(ApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> Index(SearchInFamilyRegistrationRequestsQuery query)
        {
            query.CouncilObjectkey = _currentUserService.CouncilObjectkey;
            var model = await Mediator.Send(query);

            ViewBag.QueryResult = model;

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(SearchInFamilyRegistrationRequestsQuery query)
        //{
        //    var model = await Mediator.Send(query);

        //    ViewBag.QueryResult = model;
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> SearchForCreate()
        {
            /*
                1- new  => show create
                2- exists in same project & council => show message
                3- exists in another project & same council => show create and fill data
                4- exists in another council => show messageءئئ
             */

            int councilProjectId = 1;

            ViewBag.CouncilProject = await Mediator.Send(new GetCouncilProjectByIdQuery(councilProjectId));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchForCreate(int councilProjectId, GetCanCreateStatusForIdentityNoQuery query)
        {

            ViewBag.CouncilProject = await Mediator.Send(new GetCouncilProjectByIdQuery(councilProjectId));

            if (ModelState.IsValid)
            {
                query.AssociationsAffiliatedId = _currentUserService.CouncilId;
                var result = await Mediator.Send(query);

                var personInfoByIdentityNo = await Mediator.Send(new GetPersonInfoByIdentityNoQuery(query.IdentityNo));

                switch (result.Status)
                {
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoNotUsedYet:
                        return RedirectToAction(nameof(Create), new { councilProjectId = councilProjectId, identityNo = query.IdentityNo });
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.RequestExistBefore:
                        ModelState.AddModelError("", "سبق أن تم إنشاء هذا الطلب");
                        ModelState.AddModelError("", $"{personInfoByIdentityNo.FullName} - {personInfoByIdentityNo.IdentityNo} - {personInfoByIdentityNo.MemberOrResponsibleInFamily} - {personInfoByIdentityNo.AssociationsAffiliatedWithTheCouncilName}");
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoUsedInAnotherAffiliated:
                        ModelState.AddModelError("", "سبق استخدام هذه الهوية في جمعية/جهة أخرى في المجلس");
                        ModelState.AddModelError("", $"{personInfoByIdentityNo.FullName} - {personInfoByIdentityNo.IdentityNo} - {personInfoByIdentityNo.MemberOrResponsibleInFamily} - {personInfoByIdentityNo.AssociationsAffiliatedWithTheCouncilName}");
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.ExistIn_PersonalDataForm:
                        ModelState.AddModelError("", "سبق استخدام هذه الهوية في المجلس");
                        ModelState.AddModelError("", $"{personInfoByIdentityNo.FullName} - {personInfoByIdentityNo.IdentityNo} - {personInfoByIdentityNo.MemberOrResponsibleInFamily} - {personInfoByIdentityNo.AssociationsAffiliatedWithTheCouncilName}");
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.ExistIn_ExcludeIdentityNumbers:
                        ModelState.AddModelError("", "رقم الهوية ضمن قائمة الهويات المستبعدة من المجلس");
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoDeleted:
                        ModelState.AddModelError("", "رقم الهوية سبق أن تم حذفه");
                        break;
                    case CanCreateStatusForIdentityNoDto.CanCreateStatus.AllowToCreate:
                        return RedirectToAction(nameof(Create), new { councilProjectId = councilProjectId, BaseRequestId = result.BaseRequestId, identityNo = query.IdentityNo });
                        break;
                    default:
                        break;
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(int councilProjectId, int? BaseRequestId, string identityNo)
        {
            var command = new CreateFamilyCommand();
            command.CouncilProjectId = councilProjectId;
            command.PersonalDataForm = new Application.Common.Models.RequestForms.PersonalDataFormModel() { IdentityNo = identityNo };



            if (BaseRequestId.HasValue)
            {
                var personalDataForm = await Mediator.Send(new GetByBaseRequestIdQuery(BaseRequestId.Value));
                command.PersonalDataForm = new Application.Common.Models.RequestForms.PersonalDataFormModel()
                {
                    DateOfBirth = personalDataForm.DateOfBirth,
                    FamilyName = personalDataForm.FamilyName,
                    FatherName = personalDataForm.FatherName,
                    FirstName = personalDataForm.FirstName,
                    GenderId = personalDataForm.Gender,
                    GrandFatherName = personalDataForm.GrandFatherName,
                    //IdentityFilePath = personalDataForm.IdentityFilePath,
                    IdentityNo = personalDataForm.IdentityNo,
                    NationalityId = personalDataForm.NationalityId,
                    Id = personalDataForm.Id,
                    //PersonalPhotoFilePath = personalDataForm.PersonalPhotoFilePath,
                    PlaceOfBirth = personalDataForm.PlaceOfBirth,
                };
            }

            await Create_fillData(councilProjectId, _currentUserService.CouncilId);

            return View(command);
        }

        private async Task Create_fillData(int councilProjectId, int associationsAffiliatedId)
        {
            ViewBag.CouncilProject = await Mediator.Send(new GetCouncilProjectByIdQuery(councilProjectId));
            ViewBag.AssociationAffiliatedProjectId = await Mediator.Send(new GetByAssociationsAffiliatedIdAndcouncilProjectIdQuery(associationsAffiliatedId, councilProjectId));

            ViewBag.AccommodationTypeId = await Mediator.Send(new GetAccommodationTypesQuery());
            ViewBag.EducationalLevelId = await Mediator.Send(new GetEducationalLevelsQuery());
            ViewBag.EstimatedProjectCostId = await Mediator.Send(new GetEstimatedProjectCostsQuery());
            ViewBag.FinanceTypeId = await Mediator.Send(new GetFinanceTypesQuery());
            ViewBag.HealthStatusId = await Mediator.Send(new GetHealthStatusesQuery());
            ViewBag.LoanTypeId = await Mediator.Send(new GetLoanTypesQuery());
            ViewBag.MaritalStatusId = await Mediator.Send(new GetMaritalStatusesQuery());
            ViewBag.MonthlyIncomeId = await Mediator.Send(new GetMonthlyIncomesQuery());
            ViewBag.NationalityId = await Mediator.Send(new GetNationalitiesQuery());
            ViewBag.OccupationId = await Mediator.Send(new GetOccupationsQuery());
            ViewBag.ProducedFamilyProductId = await Mediator.Send(new GetProducedFamilyProductsQuery());
            ViewBag.FamilyNeeds = await Mediator.Send(new GetFamilyNeedsQuery());
            ViewBag.FamilyCategoryId = await Mediator.Send(new GetFamilyCategoriesQuery());
            ViewBag.GenderId = await Mediator.Send(new GetGendersQuery());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFamilyCommand command)
        {


            if (ModelState.IsValid)
            {
                command.AssociationAffiliatedId = _currentUserService.CouncilId;
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            await Create_fillData(command.CouncilProjectId, _currentUserService.CouncilId);


            return View(command);
        }


        [HttpGet]
        public async Task<IActionResult> Create_ResponsibleFamilyMember(int councilProjectId, int? BaseRequestId, string identityNo)
        {
            var command = new CreateFamilyCommand();
            command.CouncilProjectId = councilProjectId;
            command.PersonalDataForm = new Application.Common.Models.RequestForms.PersonalDataFormModel() { IdentityNo = identityNo };



            if (BaseRequestId.HasValue)
            {
                var personalDataForm = await Mediator.Send(new GetByBaseRequestIdQuery(BaseRequestId.Value));
                command.PersonalDataForm = new Application.Common.Models.RequestForms.PersonalDataFormModel()
                {
                    DateOfBirth = personalDataForm.DateOfBirth,
                    FamilyName = personalDataForm.FamilyName,
                    FatherName = personalDataForm.FatherName,
                    FirstName = personalDataForm.FirstName,
                    GenderId = personalDataForm.Gender,
                    GrandFatherName = personalDataForm.GrandFatherName,
                    //IdentityFilePath = personalDataForm.IdentityFilePath,
                    IdentityNo = personalDataForm.IdentityNo,
                    NationalityId = personalDataForm.NationalityId,
                    Id = personalDataForm.Id,
                    //PersonalPhotoFilePath = personalDataForm.PersonalPhotoFilePath,
                    PlaceOfBirth = personalDataForm.PlaceOfBirth,
                };
            }

            await Create_fillData(councilProjectId, _currentUserService.CouncilId);

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Create_ResponsibleFamilyMember(CreateFamilyCommand command)
        {


            if (ModelState.IsValid)
            {
                //command.AssociationAffiliatedId = 1;
                //await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            await Create_fillData(command.CouncilProjectId, 1);


            return View(command);
        }


        public async Task<IActionResult> Details(Guid familyObjectkey)
        {
            var model = await Mediator.Send(new GetByObjectkeyQuery(familyObjectkey));

            return View(model);
        }


        public async Task<IActionResult> ExportFamilyRegistrationRequests()
        {
            var vm = await Mediator.Send(new ExportFamilyRegistrationRequestsQuery() { CouncilId = _currentUserService.CouncilId });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        public async Task<IActionResult> ExportFamilyMembers()
        {
            var vm = await Mediator.Send(new ExportFamilyMembersQuery() { CouncilId = _currentUserService.CouncilId });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        public async Task<IActionResult> ExportSupportingFamilyRequests()
        {
            var vm = await Mediator.Send(new ExportSupportingFamilyRequestsQuery() { CouncilId = _currentUserService.CouncilId });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        public async Task<IActionResult> Delete(Guid familyObjectkey)
        {
            ViewBag.familyObjectkey = familyObjectkey;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteFamilyCommand command)
        {
            ViewBag.familyObjectkey = command.Objectkey;
            if (ModelState.IsValid == false)
            {
                return View();
            }


            var model = await Mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid familyObjectkey)
        {
            var item = await Mediator.Send(new GetByObjectkeyQuery(familyObjectkey));
            ViewBag.Item = item;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Batheer.Application.Families.Queries.GetByObjectkey.FamilyDetailsDto, UpdateFamilyCommand>()
                .ForMember(d => d.FamilyNeedIds, opt => opt.MapFrom(m => m.FamilyNeeds.Select(s => s.FamilyNeedId)));
            });
            var mapper = new Mapper(config);
            var command = mapper.Map<UpdateFamilyCommand>(item);

            await Create_fillData(item.CouncilProjectId, _currentUserService.CouncilId);

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateFamilyCommand command, Guid familyObjectkey)
        {


            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            var item = await Mediator.Send(new GetByObjectkeyQuery(command.Objectkey));
            ViewBag.Item = item;

            await Create_fillData(item.CouncilProjectId, _currentUserService.CouncilId);


            return View(command);
        }
    }
}
