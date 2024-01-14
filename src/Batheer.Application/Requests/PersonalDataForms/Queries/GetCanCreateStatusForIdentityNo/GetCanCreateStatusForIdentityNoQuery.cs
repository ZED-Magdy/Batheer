using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Requests.PersonalDataForms.Queries.GetCanCreateStatusForIdentityNo
{
    public class GetCanCreateStatusForIdentityNoQuery : IRequest<CanCreateStatusForIdentityNoDto>
    {
        public GetCanCreateStatusForIdentityNoQuery()
        {

        }
        public string IdentityNo { get; set; }
        public int AssociationsAffiliatedId { get; set; }
        //public int CouncilProjectId { get; }
    }

    public class GetGetCanCreateStatusForIdentityNoQueryHandler : IRequestHandler<GetCanCreateStatusForIdentityNoQuery, CanCreateStatusForIdentityNoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public GetGetCanCreateStatusForIdentityNoQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetCanCreateStatusForIdentityNoQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<CanCreateStatusForIdentityNoDto> Handle(GetCanCreateStatusForIdentityNoQuery request, CancellationToken cancellationToken)
        {

            //var isDeleted = _queryExecuter.Scalar<bool>("EXEC [dbo].[IsIdentityNoDeleted] @IdentityNo", new { request.IdentityNo });
            //if (isDeleted)
            //{
            //    return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoDeleted };
            //}



            var isRequestExistBefore = await _context
               .FamilyRegistrationRequests
               .Where(w => w.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo)
               .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedId)
               //.Where(w => w.CouncilProjectId == request.CouncilProjectId) -- دائما دعم اسر
               .AnyAsync(cancellationToken);

            if (isRequestExistBefore)
            {
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.RequestExistBefore };
            }

            var isUsedInAnotherAffiliated = await _context
                .FamilyRegistrationRequests
                .Where(w => w.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo)
                .Where(w => w.AssociationsAffiliatedWithTheCouncilId != request.AssociationsAffiliatedId)
                .AnyAsync(cancellationToken);

            if (isUsedInAnotherAffiliated)
            {
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoUsedInAnotherAffiliated };
            }

            var rfm = await _context
                            .Families
                            .Include(i => i.ResponsibleFamilyMember.PersonalDataForm)
                            .Where(a => a.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo.Trim())
                            .ToListAsync();
            if (rfm.Count != 0)
            {
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.ExistIn_PersonalDataForm };
            }

            var fm = await _context.FamilyMembers
                .Include(i => i.Family)
                .Where(w => w.PersonalDataForm.IdentityNo == request.IdentityNo.Trim())
                .ToListAsync();
            if (fm.Count != 0)
            {
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.ExistIn_PersonalDataForm };
            }
            //

            var isExists_ExcludeIdentityNumbers = await _context.ExcludeIdentityNumbers.AnyAsync(a => a.IdentityNo == request.IdentityNo);
            if (isExists_ExcludeIdentityNumbers)
            {
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.ExistIn_ExcludeIdentityNumbers };
            }

            int lastBaseRequestId = await _context
                   .FamilyRegistrationRequests
                   .OrderByDescending(o => o.Id)
                   .Where(w => w.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo)
                   .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedId)
                   .Select(s => s.Id)
                   .FirstOrDefaultAsync(cancellationToken);

            if (lastBaseRequestId == 0)
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoNotUsedYet };





            return new CanCreateStatusForIdentityNoDto()
            {
                Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.AllowToCreate,
                BaseRequestId = lastBaseRequestId,
            };
        }


        public async Task<CanCreateStatusForIdentityNoDto> _Handle(GetCanCreateStatusForIdentityNoQuery request, CancellationToken cancellationToken)
        {

            var f = _queryExecuter.Query<Family>("select * from Families where IsDeleted = 1");
            var FindAsync = await _context
                            .Families
                            .FindAsync(627);


            var rfvm = await _context
                .Families
                .Where(w => w.IsDeleted == true)
                .ToListAsync();

            var rfm = await _context
                .Families
                .Include(i => i.ResponsibleFamilyMember.PersonalDataForm)
                .Where(a => a.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo.Trim())
                .ToListAsync();
            if (rfm.Count != 0)
            {
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.ExistIn_PersonalDataForm };
            }

            var fm = await _context.FamilyMembers
                .Include(i => i.Family)
                .Where(w => w.PersonalDataForm.IdentityNo == request.IdentityNo.Trim())
                .ToListAsync();
            if (fm.Count != 0)
            {
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.ExistIn_PersonalDataForm };
            }


            var isRequestExistBefore = await _context
               .FamilyRegistrationRequests
               .Include(i => i.Family)
               .Where(w => w.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo)
               .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedId)
               //.Where(w => w.CouncilProjectId == request.CouncilProjectId) -- دائما دعم اسر
               .AnyAsync(cancellationToken);

            if (isRequestExistBefore)
            {
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.RequestExistBefore };
            }

            var isUsedInAnotherAffiliated = await _context
                .FamilyRegistrationRequests
                .Include(i => i.Family)
                .Where(w => w.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo)
                .Where(w => w.AssociationsAffiliatedWithTheCouncilId != request.AssociationsAffiliatedId)
                .AnyAsync(cancellationToken);

            if (isUsedInAnotherAffiliated)
            {
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoUsedInAnotherAffiliated };
            }



            var isExists_ExcludeIdentityNumbers = await _context.ExcludeIdentityNumbers.AnyAsync(a => a.IdentityNo == request.IdentityNo);
            if (isExists_ExcludeIdentityNumbers)
            {
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.ExistIn_ExcludeIdentityNumbers };
            }

            int lastBaseRequestId = await _context
                   .FamilyRegistrationRequests
                   .Include(i => i.Family)
                   .OrderByDescending(o => o.Id)
                   .Where(w => w.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo)
                   .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedId)
                   .Select(s => s.Id)
                   .FirstOrDefaultAsync(cancellationToken);

            if (lastBaseRequestId == 0)
                return new CanCreateStatusForIdentityNoDto() { Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.IdentityNoNotUsedYet };





            return new CanCreateStatusForIdentityNoDto()
            {
                Status = CanCreateStatusForIdentityNoDto.CanCreateStatus.AllowToCreate,
                BaseRequestId = lastBaseRequestId,
            };
        }

    }
}
