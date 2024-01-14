using AutoMapper;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.VisitingFamilyResults.Commands.SaveVisitingFamilyResult
{
    public class SaveVisitingFamilyResultCommand : IRequest<int>
    {
        public int? VisitingFamilyResultId { get; set; }
        public Guid FamilyObjectkey { get; set; }
        public bool DidYouVisitTheFamily { get; set; }
        public string GeneralNots { get; set; }
        public bool IsDeserveSupport { get; set; }
        public string WhyNoDeserveSupport { get; set; }
    }

    public class SaveVisitingFamilyResultCommandHandler : IRequestHandler<SaveVisitingFamilyResultCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public SaveVisitingFamilyResultCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<SaveVisitingFamilyResultCommand> logger, IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(SaveVisitingFamilyResultCommand request, CancellationToken cancellationToken)
        {

            VisitingFamilyResult entity;

            if (request.VisitingFamilyResultId.HasValue && request.VisitingFamilyResultId.Value != 0) // update
            {
                entity = await _context.VisitingFamilyResults.SingleOrDefaultAsync(s => s.Id == request.VisitingFamilyResultId);

                if (entity.CreatedBy == _currentUserService.UserId && entity.Created.AddDays(30) >= _dateTime.Now)
                {
                    entity.DidYouVisitTheFamily = request.DidYouVisitTheFamily;
                    entity.GeneralNots = request.GeneralNots;
                    entity.IsDeserveSupport = request.IsDeserveSupport;
                    entity.WhyNoDeserveSupport = request.WhyNoDeserveSupport;

                    await _context.SaveChangesAsync(cancellationToken);

                    return entity.Id;
                }
            }

            var family = await _context.Families.SingleOrDefaultAsync(s => s.objectkey == request.FamilyObjectkey);

            entity = new VisitingFamilyResult()
            {
                DidYouVisitTheFamily = request.DidYouVisitTheFamily,
                GeneralNots = request.GeneralNots,
                FamilyId = family.Id,
                IsDeserveSupport = request.IsDeserveSupport,
                WhyNoDeserveSupport = request.WhyNoDeserveSupport,
            };

            _context.VisitingFamilyResults.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
