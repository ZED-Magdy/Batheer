using Batheer.Application.AssociationAffiliatedProjects.Queries.GetByAssociationsAffiliatedIdAndcouncilProjectId;
using Batheer.Application.CouncilProjects.Queries.GetCouncilProjectById;
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
using Batheer.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Batheer.Application.Modules.Lookups.Queries.GetGenders;
using Microsoft.AspNetCore.Authorization;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Families.Queries.GetByObjectkey;
using Batheer.Application.Families.Commands.UpdateFamily;
using AutoMapper;
using Batheer.Application.VisitingFamilyResults.Commands.SaveVisitingFamilyResult;
using Batheer.Application.VisitingFamilyResults.Queries.GetVisitingFamilyResultsByUser;
using Batheer.Application.Families.Commands.DeleteFamily;
using Batheer.Application.Common.Exceptions;

namespace Batheer.WebUI.Areas.Researcher.Controllers
{
    [Area("Researcher")]
    [Authorize(Roles = "Researcher")]
    public class ManageFamiliesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;



        public ManageFamiliesController(ApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
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


        public async Task<IActionResult> Edit(Guid familyObjectkey)
        {
            var item = await Mediator.Send(new GetByObjectkeyQuery(familyObjectkey));
            ViewBag.Item = item;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Application.Families.Queries.GetByObjectkey.FamilyDetailsDto, UpdateFamilyCommand>()
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
                return RedirectToAction(nameof(Edit), new { familyObjectkey = familyObjectkey });
            }

            var item = await Mediator.Send(new GetByObjectkeyQuery(command.Objectkey));
            ViewBag.Item = item;

            await Create_fillData(item.CouncilProjectId, _currentUserService.CouncilId);


            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> VisitingFamilyResult(SaveVisitingFamilyResultCommand command, Guid familyObjectkey)
        {


            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction(nameof(Edit), new { familyObjectkey = familyObjectkey });
            }

            var item = await Mediator.Send(new GetByObjectkeyQuery(familyObjectkey));
            ViewBag.Item = item;

            await Create_fillData(item.CouncilProjectId, _currentUserService.CouncilId);



            return View(nameof(Edit));
        }


        public async Task<IActionResult> VisitingFamilyResult(Guid familyObjectkey)
        {
            ViewBag.FamilyObjectkey = familyObjectkey;
            return View();
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
          
            return RedirectToAction("SearchByIdentityNo", "Home");
        }

    }
}
