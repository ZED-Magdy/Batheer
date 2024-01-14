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
    public class SearchInFamiliesExportQuery : BaseRequest, IRequest<SearchInFamiliesExportVM>
    {
        
    }

    public class SearchInFamiliesExportQueryHandler : IRequestHandler<SearchInFamiliesExportQuery, SearchInFamiliesExportVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;
        private readonly ICsvFileBuilder _fileBuilder;
        private readonly IDateTime _dateTime;

        public SearchInFamiliesExportQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<SearchInFamiliesExportQuery> logger, IQueryExecuter queryExecuter, ICsvFileBuilder fileBuilder, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
            _fileBuilder = fileBuilder;
            _dateTime = dateTime;
        }

        public async Task<SearchInFamiliesExportVM> Handle(SearchInFamiliesExportQuery request, CancellationToken cancellationToken)
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


            var records = _queryExecuter.Query<SearchInFamiliesDto>(
                "EXEC [dbo].[SP_SearchInFamilies] " +
                string.Join(',', paramNames),
                parameters);

            var vm = new SearchInFamiliesExportVM();
            vm.Content = _fileBuilder.BuildSearchInFamiliesDtoFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = $"SearchInFamilies_{_dateTime.Now.ToLongDateString()}.csv";

            return await Task.FromResult(vm);
        }

    }
}
