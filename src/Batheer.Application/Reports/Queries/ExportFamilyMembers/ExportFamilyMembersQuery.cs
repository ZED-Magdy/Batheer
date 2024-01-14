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


namespace Batheer.Application.Reports.Queries.ExportFamilyMembers
{
    public class ExportFamilyMembersQuery : IRequest<ExportFamilyMembersVM>
    {
        public int CouncilId { get; init; }
    }

    public class ExportFamilyMembersHandler : IRequestHandler<ExportFamilyMembersQuery, ExportFamilyMembersVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;
        private readonly ICsvFileBuilder _fileBuilder;
        private readonly IDateTime _dateTime;

        public ExportFamilyMembersHandler(IApplicationDbContext context, IMapper mapper, ILogger<ExportFamilyMembersQuery> logger, IQueryExecuter queryExecuter, ICsvFileBuilder fileBuilder, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
            _fileBuilder = fileBuilder;
            _dateTime = dateTime;
        }

        public async Task<ExportFamilyMembersVM> Handle(ExportFamilyMembersQuery request, CancellationToken cancellationToken)
        {

            var parameters = new
            {
                request.CouncilId,
            };

            var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);


            var records = _queryExecuter.Query<ExportFamilyMembersDto>(
                "EXEC [dbo].[SP_Export_FamilyMembersByCouncilId] " +
                string.Join(',', paramNames),
                parameters);

            var vm = new ExportFamilyMembersVM();
            vm.Content = _fileBuilder.BuildExportFamilyMembersDtoFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = $"ExportFamilyMembers_{_dateTime.Now.ToLongDateString()}.csv";

            return await Task.FromResult(vm);

        }

    }
}
