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


namespace Batheer.Application.TheIntendedBeneficiaries.Queries.GetUnAssignedByTargetedSchedulingForProjectImplementationId
{
    public class GetUnAssignedByTargetedSchedulingForProjectImplementationIdQuery : IRequest<IEnumerable<UnAssignedToTargetedSchedulingForProjectImplementation>>
    {
        public int TargetedSchedulingForProjectImplementationId { get; }

        public GetUnAssignedByTargetedSchedulingForProjectImplementationIdQuery(int targetedSchedulingForProjectImplementationId)
        {
            TargetedSchedulingForProjectImplementationId = targetedSchedulingForProjectImplementationId;
        }
    }

    public class GetUnAssignedByTargetedSchedulingForProjectImplementationIdQueryHandler : IRequestHandler<GetUnAssignedByTargetedSchedulingForProjectImplementationIdQuery, IEnumerable<UnAssignedToTargetedSchedulingForProjectImplementation>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetUnAssignedByTargetedSchedulingForProjectImplementationIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetUnAssignedByTargetedSchedulingForProjectImplementationIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<UnAssignedToTargetedSchedulingForProjectImplementation>> Handle(GetUnAssignedByTargetedSchedulingForProjectImplementationIdQuery request, CancellationToken cancellationToken)
        {
            /*
             * 
             * احتاج نجلب الغير مستهدفين
             */

            var targetedSchedulingForProjectImplementation = await _context
                .TargetedSchedulingForProjectImplementations
                .Include(i => i.AssociationAffiliatedProject)
                .Where(w => w.Id == request.TargetedSchedulingForProjectImplementationId)
                .FirstOrDefaultAsync(cancellationToken);

            var familyIds = await _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                .Where(w => w.TargetedSchedulingForProjectImplementationId == request.TargetedSchedulingForProjectImplementationId)
                .Select(s => s.FamilyId)
                .ToListAsync(cancellationToken);

            //var result = await _context.PersonalDataForm
            //    .Include(i => i.BaseRequests)
            //    .Where(w => w.BaseRequests.Any(a=> a.CouncilProjectId == targetedSchedulingForProjectImplementation.AssociationAffiliatedProject.CouncilProjectId))
            //    .Where(w => w.BaseRequests.Any(a => a.AssociationsAffiliatedWithTheCouncilId == targetedSchedulingForProjectImplementation.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncilId))
            //    .Where(w => BaseRequestIds.Contains(w.Id) == false)
            //    .SelectMany(s=> s.BaseRequests)
            //    .ProjectTo<UnAssignedToTargetedSchedulingForProjectImplementation>(_mapper.ConfigurationProvider)
            //    .ToListAsync();


            var ein = await _context.ExcludeIdentityNumbers.Select(s => s.IdentityNo).ToListAsync(cancellationToken);
            var ExcludeIdentityNumbers_ResponsibleFamilyMember_FamilyIDs = await _context.Families
                .Where(w => w.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncilId == targetedSchedulingForProjectImplementation.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncilId)
                .Where(w => ein.Contains(w.ResponsibleFamilyMember.PersonalDataForm.IdentityNo))
                .Select(s => s.Id)
                .ToListAsync(cancellationToken);

            var ExcludeIdentityNumbers_FamilyMembers_FamilyIDs = await _context.Families
                .Where(w => w.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncilId == targetedSchedulingForProjectImplementation.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncilId)
                .Where(w => w.FamilyMembers.Any(ww=> ein.Contains(ww.PersonalDataForm.IdentityNo)))
                .Select(s => s.Id)
                .ToListAsync(cancellationToken);



            var result = await _context.FamilyRegistrationRequests
              //.Include(i => i.BaseRequests)
              .Where(w => w.CouncilProjectId == targetedSchedulingForProjectImplementation.AssociationAffiliatedProject.CouncilProjectId)
              .Where(w => w.AssociationsAffiliatedWithTheCouncilId == targetedSchedulingForProjectImplementation.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncilId)
              .Where(w => familyIds.Contains(w.FamilyId) == false)
              .Where(w => ExcludeIdentityNumbers_ResponsibleFamilyMember_FamilyIDs.Contains(w.FamilyId) == false)
              .Where(w => ExcludeIdentityNumbers_FamilyMembers_FamilyIDs.Contains(w.FamilyId) == false)
              .ProjectTo<UnAssignedToTargetedSchedulingForProjectImplementation>(_mapper.ConfigurationProvider)
              .ToListAsync();

            //var result = await _context
            //    .TheIntendedBeneficiariesOfTheScheduledAssociationProjects
            //    .Include(t => t.TargetedSchedulingForProjectImplementation)
            //    //.OrderBy(o => o.FullName)
            //    .ProjectTo<UnAssignedToTargetedSchedulingForProjectImplementation>(_mapper.ConfigurationProvider)
            //    .ToListAsync();

            return result;
        }

    }
}
