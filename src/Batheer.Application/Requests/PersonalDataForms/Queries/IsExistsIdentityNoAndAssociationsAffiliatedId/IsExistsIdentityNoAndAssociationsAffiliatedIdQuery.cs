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

namespace Batheer.Application.Requests.PersonalDataForms.Queries.IsExistsIdentityNoAndAssociationsAffiliatedId
{
    public class IsExistsIdentityNoAndAssociationsAffiliatedIdQuery : IRequest<IsExistsIdentityNoAndAssociationsAffiliatedIdDto>
    {
        public IsExistsIdentityNoAndAssociationsAffiliatedIdQuery(string identityNo, int associationsAffiliatedId)
        {
            IdentityNo = identityNo;
            AssociationsAffiliatedId = associationsAffiliatedId;
        }
        public string IdentityNo { get; }
        public int AssociationsAffiliatedId { get; }
    }

    public class GetIsExistsIdentityNoAndAssociationsAffiliatedIdQueryHandler : IRequestHandler<IsExistsIdentityNoAndAssociationsAffiliatedIdQuery, IsExistsIdentityNoAndAssociationsAffiliatedIdDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetIsExistsIdentityNoAndAssociationsAffiliatedIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<IsExistsIdentityNoAndAssociationsAffiliatedIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IsExistsIdentityNoAndAssociationsAffiliatedIdDto> Handle(IsExistsIdentityNoAndAssociationsAffiliatedIdQuery request, CancellationToken cancellationToken)
        {
            var result1 = await _context
                .FamilyRegistrationRequests
                .Where(w => w.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo)
                .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedId)
                .ProjectTo<IsExistsIdentityNoAndAssociationsAffiliatedIdDto>(_mapper.ConfigurationProvider)
                .ToListAsync();


            // return result1.FirstOrDefault();


            if (result1.Count == 0)
            {
                return new IsExistsIdentityNoAndAssociationsAffiliatedIdDto() { Result = false };
            }
            else
            {
                var item = result1.First();
                return new IsExistsIdentityNoAndAssociationsAffiliatedIdDto() { Result = true, PersonalDataFormId = item.PersonalDataFormId, BaseRequestId = item.BaseRequestId };
            }
        }

    }
}
