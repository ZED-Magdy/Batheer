using Batheer.Application.Modules.Lookups.Queries.GetAccommodationTypes;
using Batheer.Application.Modules.Lookups.Queries.GetCities;
using Batheer.Application.Modules.Lookups.Queries.GetClassifications;
using Batheer.Application.Modules.Lookups.Queries.GetEducationalLevels;
using Batheer.Application.Modules.Lookups.Queries.GetEstimatedProjectCosts;
using Batheer.Application.Modules.Lookups.Queries.GetFamilyCategories;
using Batheer.Application.Modules.Lookups.Queries.GetFamilyNeeds;
using Batheer.Application.Modules.Lookups.Queries.GetFinanceTypes;
using Batheer.Application.Modules.Lookups.Queries.GetGenders;
using Batheer.Application.Modules.Lookups.Queries.GetHealthStatuses;
using Batheer.Application.Modules.Lookups.Queries.GetLoanTypes;
using Batheer.Application.Modules.Lookups.Queries.GetMaritalStatuses;
using Batheer.Application.Modules.Lookups.Queries.GetMonthlyIncomes;
using Batheer.Application.Modules.Lookups.Queries.GetNationalities;
using Batheer.Application.Modules.Lookups.Queries.GetOccupations;
using Batheer.Application.Modules.Lookups.Queries.GetProducedFamilyProducts;
using Batheer.Application.Modules.Lookups.Queries.GetRequestStatuses;
using Batheer.Application.Modules.Lookups.Queries.GetSupportingFamilyTypes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.Areas.Api.Modules
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ApiControllerBase
    {
        [HttpGet("AccommodationTypes")]
        public async Task<ActionResult<IEnumerable<Classification>>> GetAccommodationTypes()
        {
            var dto = await Mediator.Send(new GetAccommodationTypesQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }


        [HttpGet("EducationalLevels")]
        public async Task<ActionResult<IEnumerable<EducationalLevel>>> GetEducationalLevels()
        {
            var dto = await Mediator.Send(new GetEducationalLevelsQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }


        [HttpGet("EstimatedProjectCosts")]
        public async Task<ActionResult<IEnumerable<EstimatedProjectCost>>> GetEstimatedProjectCosts()
        {
            var dto = await Mediator.Send(new GetEstimatedProjectCostsQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpGet("FamilyCategories")]
        public async Task<ActionResult<IEnumerable<FamilyCategory>>> GetFamilyCategories()
        {
            var dto = await Mediator.Send(new GetFamilyCategoriesQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpGet("FamilyNeeds")]
        public async Task<ActionResult<IEnumerable<FamilyNeed>>> GetFamilyNeeds()
        {
            var dto = await Mediator.Send(new GetFamilyNeedsQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpGet("FinanceTypes")]
        public async Task<ActionResult<IEnumerable<FinanceType>>> GetFinanceTypes()
        {
            var dto = await Mediator.Send(new GetFinanceTypesQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }


        [HttpGet("Genders")]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGenders()
        {
            var dto = await Mediator.Send(new GetGendersQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpGet("HealthStatuses")]
        public async Task<ActionResult<IEnumerable<HealthStatus>>> GetHealthStatuses()
        {
            var dto = await Mediator.Send(new GetHealthStatusesQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpGet("LoanTypes")]
        public async Task<ActionResult<IEnumerable<LoanType>>> GetLoanTypes()
        {
            var dto = await Mediator.Send(new GetLoanTypesQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }


        [HttpGet("MaritalStatuses")]
        public async Task<ActionResult<IEnumerable<MaritalStatus>>> GetMaritalStatuses()
        {
            var dto = await Mediator.Send(new GetMaritalStatusesQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }


        [HttpGet("MonthlyIncomes")]
        public async Task<ActionResult<IEnumerable<MonthlyIncome>>> GetMonthlyIncomes()
        {
            var dto = await Mediator.Send(new GetMonthlyIncomesQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }


        [HttpGet("Nationalities")]
        public async Task<ActionResult<IEnumerable<Nationality>>> GetNationalities()
        {
            var dto = await Mediator.Send(new GetNationalitiesQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpGet("Occupations")]
        public async Task<ActionResult<IEnumerable<Occupation>>> GetOccupations()
        {
            var dto = await Mediator.Send(new GetOccupationsQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpGet("ProducedFamilyProducts")]
        public async Task<ActionResult<IEnumerable<ProducedFamilyProduct>>> GetProducedFamilyProducts()
        {
            var dto = await Mediator.Send(new GetProducedFamilyProductsQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpGet("RequestStatuses")]
        public async Task<ActionResult<IEnumerable<RequestStatus>>> GetRequestStatuses()
        {
            var dto = await Mediator.Send(new GetRequestStatusesQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpGet("SupportingFamilyTypes")]
        public async Task<ActionResult<IEnumerable<SupportingFamilyType>>> GetSupportingFamilyTypes()
        {
            var dto = await Mediator.Send(new GetSupportingFamilyTypesQuery());

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }
    }

}
