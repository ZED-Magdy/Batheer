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


namespace Batheer.Application.Reports.Queries.SearchInFamilies
{
    public class SearchInFamiliesQuery : BaseRequest, IRequest<IEnumerable<SearchInFamiliesDto>>
    {
        
    }

    public class SearchInFamiliesHandler : IRequestHandler<SearchInFamiliesQuery, IEnumerable<SearchInFamiliesDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public SearchInFamiliesHandler(IApplicationDbContext context, IMapper mapper, ILogger<SearchInFamiliesQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<IEnumerable<SearchInFamiliesDto>> Handle(SearchInFamiliesQuery request, CancellationToken cancellationToken)
        {

            var parameters = new
            {
                request.FullName,
                request.IdentityNo,
                request.GenderId,
                request.NationalityId,
                request.AccommodationTypeId,
                request.Email,
                request.Mobile,
                request.PhoneNumber,
                request.MaritalStatusId,
                request.EducationalLevelId,
                request.HealthStatusId,
                request.OccupationId,
                request.MonthlyIncomeId,
                request.AssociationsAffiliatedWithTheCouncilId,
                request.HasSupportingFamilyRequest,
                request.FamilyCategoryId,
                request.FamilyNeedId
            };

            var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);

            //return _queryExecuter.Query<SearchInFamiliesDto>(
            //    "EXEC [dbo].[SP_SearchInFamilies] @fullName,@identityNo," +
            //    "@genderId,@nationalityId,@AccommodationTypeId,@email,@mobile,@PhoneNumber," +
            //    "@MaritalStatusId,@EducationalLevelId,@HealthStatusId,@OccupationId,@MonthlyIncomeId," +
            //    "@AssociationsAffiliatedWithTheCouncilId,@HasSupportingFamilyRequest,@FamilyCategoryId,@FamilyNeedId",
            //    parameters);


            return _queryExecuter.Query<SearchInFamiliesDto>(
                "EXEC [dbo].[SP_SearchInFamilies] " +
                string.Join(',', paramNames),
                parameters);

        }

    }
}
