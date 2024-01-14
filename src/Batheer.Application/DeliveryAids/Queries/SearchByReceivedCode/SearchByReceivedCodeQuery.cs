using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.DeliveryAids.Queries.SearchByReceivedCode
{
    public class SearchByReceivedCodeQuery : IRequest<SearchByReceivedCodeDto>
    {
        public int FamilyId { get; set; }
        public int TheIntendedBeneficiariesOfTheScheduledAssociationProjectId { get; set; }
        public int AssociationAffiliatedId { get; set; }

        public SearchByReceivedCodeQuery()
        {
          
        }
    }

    public class SearchByReceivedCodeQueryHandler : IRequestHandler<SearchByReceivedCodeQuery, SearchByReceivedCodeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;


        public SearchByReceivedCodeQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<SearchByReceivedCodeQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<SearchByReceivedCodeDto> Handle(SearchByReceivedCodeQuery request, CancellationToken cancellationToken)
        {
            //var spliter = request.ReceivedCode.Split("-").ToList();
            //var familyId = ParseInt(spliter.ElementAt(0));
            //var theIntendedBeneficiariesOfTheScheduledAssociationProjectId = ParseInt(spliter.ElementAt(1));


            //var parameters = new
            //{
            //    familyId,
            //    theIntendedBeneficiariesOfTheScheduledAssociationProjectId
            //};

            //var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);


            //var records = _queryExecuter.Query<SearchByReceivedCodeDto>(
            //    "EXEC [dbo].[SP_Export_FamilyRegistrationRequestsByCouncilId] " +
            //    string.Join(',', paramNames),
            //    parameters);

            var result = await _context
                .TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                .Include(i => i.Family.FamilyRegistrationRequest)
                .Where(w => w.Id == request.TheIntendedBeneficiariesOfTheScheduledAssociationProjectId && 
                            w.FamilyId == request.FamilyId &&
                            w.TargetedSchedulingForProjectImplementation.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncilId == request.AssociationAffiliatedId)
                .ProjectTo<SearchByReceivedCodeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();





            return result.FirstOrDefault();
        }


        private int ParseInt(string value, int defaultIntValue = 0)
        {

            if (value is null)
                return defaultIntValue;

            int parsedInt;
            if (int.TryParse(value, out parsedInt))
            {
                return parsedInt;
            }

            return defaultIntValue;
        }

    }
}