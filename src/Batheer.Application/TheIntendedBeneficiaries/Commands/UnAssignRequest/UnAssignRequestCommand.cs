using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.TheIntendedBeneficiaries.Commands.UnAssignRequest
{
    public class UnAssignRequestCommand : IRequest<int>
    {
        public int FamilyId { get; set; }
        public int TargetedSchedulingForProjectImplementationId { get; set; }

    }

    public class UnAssignRequestCommandHandler : IRequestHandler<UnAssignRequestCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UnAssignRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<UnAssignRequestCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UnAssignRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context
                .TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                .Where(w => w.FamilyId == request.FamilyId)
                .Where(w => w.TargetedSchedulingForProjectImplementationId == request.TargetedSchedulingForProjectImplementationId)
                .ToListAsync(cancellationToken);

            _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects.RemoveRange(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return request.FamilyId;
        }

    }

}
