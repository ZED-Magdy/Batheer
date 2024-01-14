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
    public class SearchInSupportingFamilyRequestsExportQuery : BaseRequest, IRequest<SearchInSupportingFamilyRequestsExportVM>
    {

    }

    public class SearchInSupportingFamilyRequestsExportQueryHandler : IRequestHandler<SearchInSupportingFamilyRequestsExportQuery, SearchInSupportingFamilyRequestsExportVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;
        private readonly ICsvFileBuilder _fileBuilder;
        private readonly IDateTime _dateTime;

        public SearchInSupportingFamilyRequestsExportQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<SearchInSupportingFamilyRequestsQuery> logger, IQueryExecuter queryExecuter, ICsvFileBuilder fileBuilder, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
            _fileBuilder = fileBuilder;
            _dateTime = dateTime;
        }

        public async Task<SearchInSupportingFamilyRequestsExportVM> Handle(SearchInSupportingFamilyRequestsExportQuery request, CancellationToken cancellationToken)
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


            var records = _queryExecuter.Query<SearchInSupportingFamilyRequestsDto>(
                "EXEC [dbo].[SP_SearchInSupportingFamilyRequests] " +
                string.Join(',', paramNames),
                parameters);

            var vm = new SearchInSupportingFamilyRequestsExportVM();
            vm.Content = _fileBuilder.BuildSearchInSupportingFamilyRequestsDtoFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = $"SearchInSupportingFamilyRequests_{_dateTime.Now.ToLongDateString()}.csv";

            return await Task.FromResult(vm);
        }

    }
}
