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
using static Batheer.Domain.AuthenticationUsers.User;

namespace Batheer.Application.PersonalDataForms.Queries.GetPersonByIdentityNo
{
    public class GetPersonByIdentityNoQuery : IRequest<IEnumerable<PersonalDataFormDto>>
    {
        public string IdentityNo { get; }


        public GetPersonByIdentityNoQuery(string identityNo)
        {
            IdentityNo = identityNo;
        }
    }

    public class GetPersonByIdentityNoQueryHandler : IRequestHandler<GetPersonByIdentityNoQuery, IEnumerable<PersonalDataFormDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetPersonByIdentityNoQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetPersonByIdentityNoQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PersonalDataFormDto>> Handle(GetPersonByIdentityNoQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.PersonalDataForm
                .Where(w => w.IdentityNo == request.IdentityNo)
                .ProjectTo<PersonalDataFormDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            result.ForEach(pdf =>
            {
                var familyMember = _context.FamilyMembers
                .Include(i => i.Family.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncil)
                .SingleOrDefault(a => a.PersonalDataFormId == pdf.Id);
                pdf.IsInFamilyMembers = familyMember is not null;

                pdf.FamilyMemberObjectkey = familyMember?.objectkey;


                var family_ResponsibleFamilyMember = _context.Families
                .Include(i=> i.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncil)
                .SingleOrDefault(a => a.ResponsibleFamilyMember.PersonalDataFormId == pdf.Id);

                pdf.IsInResponsibleFamilyMembers = family_ResponsibleFamilyMember is not null;

                if (familyMember is not null)
                {
                    pdf.FamilyObjectkey = familyMember.Family.objectkey;
                    pdf.AssociationsAffiliatedWithTheCouncilName = familyMember.Family.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncil.Name;
                }

                if (family_ResponsibleFamilyMember is not null)
                {
                    pdf.FamilyObjectkey = family_ResponsibleFamilyMember.objectkey;
                    pdf.AssociationsAffiliatedWithTheCouncilName = family_ResponsibleFamilyMember.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncil.Name;
                }
            });

            return result;
        }

    }
}
