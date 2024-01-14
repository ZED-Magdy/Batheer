using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain.AssociationAffiliatedProjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Batheer.Application.Summaries.Queries.GetRequestsCount
{
    public class GetRequestsCountQuery : IRequest<List<RequestsCountDto>>
    {
        public int? CouncilId { get; }
        public GetRequestsCountQuery(int? councilId)
        {
            CouncilId = councilId;
        }
    }
    public class GetRequestsCountQueryHandler : IRequestHandler<GetRequestsCountQuery, List<RequestsCountDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetRequestsCountQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetRequestsCountQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<RequestsCountDto>> Handle(GetRequestsCountQuery request, CancellationToken cancellationToken)
        {

            Func<FamilyRegistrationRequest, bool> _expression;

            if (request.CouncilId.HasValue)
                _expression = i => { return i.AssociationsAffiliatedWithTheCouncilId == request.CouncilId.Value; };
            else
                _expression = i => { return true; };

            var items = new List<RequestsCountDto>();

            //var query = _context.FamilyRegistrationRequests
            //  .Where(_expression)
            //  //.Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.CouncilId)
            //  .Count();

            items.Add(new RequestsCountDto()
            {
                Key = 0,
                Value = _context.FamilyRegistrationRequests
                                .Include(f => f.Family)
                                .Where(_expression)
                                .Count()
            });


            //_context.SupportingFamilyRequests
            //    .Where(w => w.Family.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncilId == request.CouncilId)
            //    .Count();

            items.Add(new RequestsCountDto()
            {
                Key = 1,
                Value = _context.SupportingFamilyRequests
                .Include(f => f.Family)
                .Where(w => w.Family.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncilId == request.CouncilId)
                .Count()
            });


            items.Add(new RequestsCountDto()
            {
                Key = 2,
                Value = _context.FamilyRegistrationRequests
                .Include(f => f.Family)
                .Include(i=> i.Family.ResidencyAddressData)
                .Where(_expression).Where(w => w.Family.ResidencyAddressData.IsOutOfTabuk == true).Count()
            });

            //_context.FamilyRegistrationRequests
            //    .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.CouncilId)
            //    .Where(w => w.Family.ResidencyAddressData.IsOutOfTabuk == true)
            //    .Count();


            //_context.FamilyRegistrationRequests
            //   .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.CouncilId)
            //   .Where(w => w.Family.ResidencyAddressData.IsOutOfTabuk == false)
            //   .Count();



            items.Add(
                new RequestsCountDto()
                {
                    Key = 3,
                    Value = _context.FamilyRegistrationRequests
                                    .Include(f => f.Family)
                                    .Include(i => i.Family.ResidencyAddressData)
                                    .Where(_expression)
                                    .Where(w => w.Family.ResidencyAddressData.IsOutOfTabuk == false)
                                    .Count()
                });

            //_context.FamilyRegistrationRequests
            // .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.CouncilId)
            // .Where(w => w.Family.SocialSecurityData.AreYouABeneficiaryOfSocialSecurity == true)
            // .Count();

            items.Add(new RequestsCountDto()
            {
                Key = 4,
                Value = _context.FamilyRegistrationRequests
                                .Include(f => f.Family)     
                                .Include(i=>i.Family.SocialSecurityData)
                                .Where(_expression)
                                .Where(w => w.Family.SocialSecurityData.AreYouABeneficiaryOfSocialSecurity == false)
                                .Count()
            });

            //_context.FamilyRegistrationRequests
            // .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.CouncilId)
            // .Where(w => w.Family.SocialSecurityData.AreYouABeneficiaryOfSocialSecurity == true)
            // .Count();
            items.Add(new RequestsCountDto()
            {
                Key = 5,
                Value = _context.FamilyRegistrationRequests
                                .Include(f => f.Family) 
                                .Include(i => i.Family.SocialSecurityData)
                                .Where(_expression)
                                .Where(w => w.Family.SocialSecurityData.AreYouABeneficiaryOfSocialSecurity == true)
                                .Count()
            });


            //var result = await _context
            //    .RequestsCountDtos
            //    .Include(t => t.AssociationAffiliatedProject)
            //    .ThenInclude(t => t.CouncilProject)
            //    .Include(t => t.RequestsCountDtoStatus)
            //    .Where(w => w.Id == request.Id)
            //    //.OrderBy(o => o.FullName)
            //    .ProjectTo<RequestsCountDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);

            return items;
        }

    }
}
