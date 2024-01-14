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


namespace Batheer.Application.TheIntendedBeneficiaries.Queries.GetAssignedByTargetedSchedulingForProjectImplementationId
{
    public class GetAssignedByTargetedSchedulingForProjectImplementationIdQuery : IRequest<IEnumerable<AssignedToTargetedSchedulingForProjectImplementation>>
    {
        public int TargetedSchedulingForProjectImplementationId { get; }

        public GetAssignedByTargetedSchedulingForProjectImplementationIdQuery(int targetedSchedulingForProjectImplementationId)
        {
            TargetedSchedulingForProjectImplementationId = targetedSchedulingForProjectImplementationId;
        }
    }

    public class GetAssignedByTargetedSchedulingForProjectImplementationIdQueryHandler : IRequestHandler<GetAssignedByTargetedSchedulingForProjectImplementationIdQuery, IEnumerable<AssignedToTargetedSchedulingForProjectImplementation>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public GetAssignedByTargetedSchedulingForProjectImplementationIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetAssignedByTargetedSchedulingForProjectImplementationIdQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<IEnumerable<AssignedToTargetedSchedulingForProjectImplementation>> Handle(GetAssignedByTargetedSchedulingForProjectImplementationIdQuery request, CancellationToken cancellationToken)
        {

            var CouncilProjectId = _context.TargetedSchedulingForProjectImplementations
                .Where(w => w.Id == request.TargetedSchedulingForProjectImplementationId)
                .Select(s => s.AssociationAffiliatedProject.CouncilProjectId)
                .FirstOrDefault();

            if (CouncilProjectId == 1)  // دعم الأسر
            {
                /*
                var result = await _context
                             .TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                             .Include(i => i.Family.FamilyRegistrationRequest)
                             .Where(w => w.TargetedSchedulingForProjectImplementationId == request.TargetedSchedulingForProjectImplementationId)
                             .ProjectTo<AssignedToTargetedSchedulingForProjectImplementation>(_mapper.ConfigurationProvider)
                             .ToListAsync();

                return result;
                */
                var parameters = new
                {
                    request.TargetedSchedulingForProjectImplementationId,
                };

                //var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);
                var sql = @"SELECT ib.Id,ib.FamilyId,FirstName, FatherName, GrandFatherName, FamilyName, (FirstName + ' ' + FatherName + ' ' + GrandFatherName + ' ' + FamilyName) FullName, IdentityNo, (case when r.id is null then N'' else N'تم التسليم' end) DeliveryStatusName
, (case when ib.SmsSuccessReferenceNo is null then N'' else N'تم إرسال رمز التسليم' end) SmsSentStatusName
,TargetedSchedulingForProjectImplementationId
from TheIntendedBeneficiariesOfTheScheduledAssociationProjects ib
inner join dbo.Families f on f.id = ib.familyid
inner join dbo.ResponsibleFamilyMembers rfm on rfm.id = f.ResponsibleFamilyMemberId
inner join dbo.PersonalDataForm pdf on pdf.id = rfm.PersonalDataFormId
left join dbo.ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjects r on r.TheIntendedBeneficiariesOfTheScheduledAssociationProjectId = ib.id
where TargetedSchedulingForProjectImplementationId = @TargetedSchedulingForProjectImplementationId";
               var result = _queryExecuter.Query<AssignedToTargetedSchedulingForProjectImplementation>(sql, parameters);

                return result;
            }


            if (CouncilProjectId == 2) // الأسر المنتجة
            {
                var result = await _context
                             .TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                             .Include(i => i.Family.FamilyRegistrationRequest)
                             .Where(w => w.TargetedSchedulingForProjectImplementationId == request.TargetedSchedulingForProjectImplementationId)
                             .Where(w => w.Family.SupportingFamilyRequest != null)
                             .ProjectTo<AssignedToTargetedSchedulingForProjectImplementation>(_mapper.ConfigurationProvider)
                             .ToListAsync();

                return result;
            }

            return null;
        }

    }
}
