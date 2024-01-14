using AutoMapper;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.VisitingFamilyMemberResults.Commands.SaveVisitingFamilyMemberResult
{
    public class SaveVisitingFamilyMemberResultCommand : IRequest<int>
    {
        public int? VisitingFamilyMemberResultId { get; set; }
        public Guid FamilyMemberObjectkey { get; set; }
        public bool DidYouVisitTheFamilyMember { get; set; }
        public string GeneralNots { get; set; }
        public bool IsDeserveSupport { get; set; }
        public string WhyNoDeserveSupport { get; set; }
    }

    public class SaveVisitingFamilyMemberResultCommandHandler : IRequestHandler<SaveVisitingFamilyMemberResultCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public SaveVisitingFamilyMemberResultCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<SaveVisitingFamilyMemberResultCommand> logger, IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(SaveVisitingFamilyMemberResultCommand request, CancellationToken cancellationToken)
        {

            VisitingFamilyMemberResult entity;

            if (request.VisitingFamilyMemberResultId.HasValue && request.VisitingFamilyMemberResultId.Value != 0) // update
            {
                entity = await _context.VisitingFamilyMemberResults.SingleOrDefaultAsync(s => s.Id == request.VisitingFamilyMemberResultId);

                if (entity.CreatedBy == _currentUserService.UserId && entity.Created.AddDays(30) >= _dateTime.Now)
                {
                    entity.DidYouVisitTheFamilyMember = request.DidYouVisitTheFamilyMember;
                    entity.GeneralNots = request.GeneralNots;
                    entity.IsDeserveSupport = request.IsDeserveSupport;
                    entity.WhyNoDeserveSupport = request.WhyNoDeserveSupport;

                    await _context.SaveChangesAsync(cancellationToken);

                    return entity.Id;
                }
            }

            var familyMember = await _context.FamilyMembers.SingleOrDefaultAsync(s => s.objectkey == request.FamilyMemberObjectkey);

            entity = new VisitingFamilyMemberResult()
            {
                DidYouVisitTheFamilyMember = request.DidYouVisitTheFamilyMember,
                GeneralNots = request.GeneralNots,
                FamilyMemberId = familyMember.Id,
                IsDeserveSupport = request.IsDeserveSupport,
                WhyNoDeserveSupport = request.WhyNoDeserveSupport,
            };

            _context.VisitingFamilyMemberResults.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
