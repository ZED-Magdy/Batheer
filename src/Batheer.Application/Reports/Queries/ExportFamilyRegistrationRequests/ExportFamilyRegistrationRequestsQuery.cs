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


namespace Batheer.Application.Reports.Queries.ExportFamilyRegistrationRequests
{
    public class ExportFamilyRegistrationRequestsQuery : IRequest<ExportFamilyRegistrationRequestsVM>
    {
        public int CouncilId { get; init; }
    }

    public class ExportFamilyRegistrationRequestsHandler : IRequestHandler<ExportFamilyRegistrationRequestsQuery, ExportFamilyRegistrationRequestsVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;
        private readonly ICsvFileBuilder _fileBuilder;
        private readonly IDateTime _dateTime;

        public ExportFamilyRegistrationRequestsHandler(IApplicationDbContext context, IMapper mapper, ILogger<ExportFamilyRegistrationRequestsQuery> logger, IQueryExecuter queryExecuter, ICsvFileBuilder fileBuilder, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
            _fileBuilder = fileBuilder;
            _dateTime = dateTime;
        }

        public async Task<ExportFamilyRegistrationRequestsVM> Handle(ExportFamilyRegistrationRequestsQuery request, CancellationToken cancellationToken)
        {

            var parameters = new
            {
                request.CouncilId,
            };

            var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);


            var records = _queryExecuter.Query<ExportFamilyRegistrationRequestsDto>(
                "EXEC [dbo].[SP_Export_FamilyRegistrationRequestsByCouncilId] " +
                string.Join(',', paramNames),
                parameters);

            var vm = new ExportFamilyRegistrationRequestsVM();
            vm.Content = _fileBuilder.BuildExportFamilyRegistrationRequestsDtoFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = $"ExportFamilyRegistrationRequests_{_dateTime.Now.ToLongDateString()}.csv";

            return await Task.FromResult(vm);

        }

    }
}
