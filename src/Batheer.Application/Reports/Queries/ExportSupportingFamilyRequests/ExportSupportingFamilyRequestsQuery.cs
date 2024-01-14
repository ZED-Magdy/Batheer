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


namespace Batheer.Application.Reports.Queries.ExportSupportingFamilyRequests
{
    public class ExportSupportingFamilyRequestsQuery : IRequest<ExportSupportingFamilyRequestsVM>
    {
        public int CouncilId { get; init; }
    }

    public class ExportSupportingFamilyRequestsHandler : IRequestHandler<ExportSupportingFamilyRequestsQuery, ExportSupportingFamilyRequestsVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;
        private readonly ICsvFileBuilder _fileBuilder;
        private readonly IDateTime _dateTime;

        public ExportSupportingFamilyRequestsHandler(IApplicationDbContext context, IMapper mapper, ILogger<ExportSupportingFamilyRequestsQuery> logger, IQueryExecuter queryExecuter, ICsvFileBuilder fileBuilder, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
            _fileBuilder = fileBuilder;
            _dateTime = dateTime;
        }

        public async Task<ExportSupportingFamilyRequestsVM> Handle(ExportSupportingFamilyRequestsQuery request, CancellationToken cancellationToken)
        {

            var parameters = new
            {
                request.CouncilId,
            };

            var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);


            var records = _queryExecuter.Query<ExportSupportingFamilyRequestsDto>(
                "EXEC [dbo].[SP_Export_SupportingFamilyRequestsByCouncilId] " +
                string.Join(',', paramNames),
                parameters);

            var vm = new ExportSupportingFamilyRequestsVM();
            vm.Content = _fileBuilder.BuildExportSupportingFamilyRequestsDtoFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = $"ExportSupportingFamilyRequests_{_dateTime.Now.ToLongDateString()}.csv";

            return await Task.FromResult(vm);

        }

    }
}
