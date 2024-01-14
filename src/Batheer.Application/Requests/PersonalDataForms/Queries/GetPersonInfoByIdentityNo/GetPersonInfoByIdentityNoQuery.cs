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

namespace Batheer.Application.Requests.PersonalDataForms.Queries.GetPersonInfoByIdentityNo
{
    public class GetPersonInfoByIdentityNoQuery : IRequest<GetPersonInfoByIdentityNoDto>
    {
        public GetPersonInfoByIdentityNoQuery(string identityNo)
        {
            IdentityNo = identityNo;
        }
        public string IdentityNo { get; }
    }

    public class GetGetPersonInfoByIdentityNoQueryHandler : IRequestHandler<GetPersonInfoByIdentityNoQuery, GetPersonInfoByIdentityNoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetGetPersonInfoByIdentityNoQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetPersonInfoByIdentityNoQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetPersonInfoByIdentityNoDto> Handle(GetPersonInfoByIdentityNoQuery request, CancellationToken cancellationToken)
        {

            var personalDataForm = await _context.PersonalDataForm
                .Where(w => w.IdentityNo == request.IdentityNo)
                .FirstOrDefaultAsync();

            if (personalDataForm is null)
                return null;

            var result = new GetPersonInfoByIdentityNoDto();
            result.FullName = $"{personalDataForm.FirstName} {personalDataForm.FatherName} {personalDataForm.GrandFatherName} {personalDataForm.FamilyName}";
            result.IdentityNo = personalDataForm.IdentityNo;

            var responsibleFamilyMember = await _context.ResponsibleFamilyMembers.Where(w => w.PersonalDataFormId == personalDataForm.Id).FirstOrDefaultAsync();

            if (responsibleFamilyMember != null)
            {
                var family = await _context.Families
                    .Include(i => i.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncil)
                    .Where(w => w.ResponsibleFamilyMemberId == responsibleFamilyMember.Id)
                    .FirstOrDefaultAsync();

                result.MemberOrResponsibleInFamily = "عائل أسرة";
                result.AssociationsAffiliatedWithTheCouncilName = family?.FamilyRegistrationRequest?.AssociationsAffiliatedWithTheCouncil?.Name;

                return result;
            }
            else
            {
                var familyMember = await _context.FamilyMembers
                    .Include(i => i.Family.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncil)
                    .Where(w => w.PersonalDataFormId == personalDataForm.Id).FirstOrDefaultAsync();

                result.MemberOrResponsibleInFamily = "فرد بعائلة";


                result.AssociationsAffiliatedWithTheCouncilName = familyMember?.Family?.FamilyRegistrationRequest?.AssociationsAffiliatedWithTheCouncil.Name;
                return result;
            }

            return null;

        }

    }
}
