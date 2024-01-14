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


namespace Batheer.Application.Summaries.Queries.GetLastFamiliesReceived
{
    public class GetLastFamiliesReceivedQuery : IRequest<List<LastFamiliesReceivedDto>>
    {
        public int? CouncilId { get; }
        public GetLastFamiliesReceivedQuery(int? councilId)
        {
            CouncilId = councilId;
        }
    }
    public class GetLastFamiliesReceivedQueryHandler : IRequestHandler<GetLastFamiliesReceivedQuery, List<LastFamiliesReceivedDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetLastFamiliesReceivedQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetLastFamiliesReceivedQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<LastFamiliesReceivedDto>> Handle(GetLastFamiliesReceivedQuery request, CancellationToken cancellationToken)
        {

            Func<Domain.TheIntendedBeneficiariesOfTheScheduledAssociationProject, bool> _expression;

            if (request.CouncilId.HasValue)
                _expression = i => { return i.TargetedSchedulingForProjectImplementation?.AssociationAffiliatedProject?.AssociationsAffiliatedWithTheCouncilId == request.CouncilId.Value; };
            else
                _expression = i => { return true; };

            var items = new List<LastFamiliesReceivedDto>();


            _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects
               .Include(i => i.TargetedSchedulingForProjectImplementation.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncil)
               .Include(i => i.Family.ResponsibleFamilyMember.PersonalDataForm.Nationality)
               .Include(i => i.Family.ResponsibleFamilyMember.PersonalDataForm.PersonalPhotoFile)
               .AsNoTracking()
               .Where(w => string.IsNullOrEmpty(w.SmsSuccessReferenceNo) == false)
               .Where(_expression)
               .OrderByDescending(o => o.Id)
               .Take(4)
               .ToList()
               .ForEach(f =>
               {
                   var i = new LastFamiliesReceivedDto();

                   var rrr = f.Family.ResponsibleFamilyMember.PersonalDataForm;
                   i.FullName = $"{rrr.FirstName} {rrr.FatherName} {rrr.GrandFatherName} {rrr.FamilyName}";
                   i.IdentityNo = rrr.IdentityNo;
                   i.Nationality_ISO_CODES = rrr.Nationality.ISO_CODES;
                   if(rrr.PersonalPhotoFileId.HasValue)
                   {
                       i.PersonalPhotoFileObjectKey = rrr.PersonalPhotoFile.ObjectKey;
                   }
                   else
                   {
                       i.PersonalPhotoFileObjectKey = Guid.Empty;
                   }
                   i.ReceivedDate = f.SmsSentDate.Value;

                   i.TheCouncilName = f.TargetedSchedulingForProjectImplementation.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncil.Name;

                   items.Add(i);
               });

            return items;
        }

    }
}
