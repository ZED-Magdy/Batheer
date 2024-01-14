using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Batheer.Application.Reports.Queries.SearchInSupportingFamilyRequests
{
    public class SearchInSupportingFamilyRequestsQuery : BaseRequest, IRequest<IEnumerable<SearchInSupportingFamilyRequestsDto>>
    {

    }

    public class SearchInSupportingFamilyRequestsHandler : IRequestHandler<SearchInSupportingFamilyRequestsQuery, IEnumerable<SearchInSupportingFamilyRequestsDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public SearchInSupportingFamilyRequestsHandler(IApplicationDbContext context, IMapper mapper, ILogger<SearchInSupportingFamilyRequestsQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<IEnumerable<SearchInSupportingFamilyRequestsDto>> Handle(SearchInSupportingFamilyRequestsQuery request, CancellationToken cancellationToken)
        {

            var parameters = new
            {
                request.FullName,
                request.IdentityNo,
                request.GenderId,
                request.NationalityId,
                request.Email,
                request.Mobile,
                request.PhoneNumber,
                request.MaritalStatusId,
                request.EducationalLevelId,
                request.HealthStatusId,
                request.OccupationId,
                request.MonthlyIncomeId,
                request.AssociationsAffiliatedWithTheCouncilId,
                request.FamilyCategoryId,
                request.EstimatedProjectCostId,
                request.LoanTypeId,
                request.ProducedFamilyProductId,
                request.FinanceTypeId,
                request.AreYouFreeAndReadyToWorkOnAproject,
                request.DoYouHaveLoansOrOtherObligations,
                request.IsThereABankDefault
            };

            var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);

            //return _queryExecuter.Query<SearchInSupportingFamilyRequestsDto>(
            //    "EXEC [dbo].[SP_SearchInSupportingFamilyRequests] @fullName,@identityNo," +
            //    "@genderId,@nationalityId,@AccommodationTypeId,@email,@mobile,@PhoneNumber," +
            //    "@MaritalStatusId,@EducationalLevelId,@HealthStatusId,@OccupationId,@MonthlyIncomeId," +
            //    "@AssociationsAffiliatedWithTheCouncilId,@HasSupportingFamilyRequest,@FamilyCategoryId,@FamilyNeedId",
            //    parameters);


            return _queryExecuter.Query<SearchInSupportingFamilyRequestsDto>(
                "EXEC [dbo].[SP_SearchInSupportingFamilyRequests] " +
                string.Join(',', paramNames),
                parameters);

        }

    }
}
