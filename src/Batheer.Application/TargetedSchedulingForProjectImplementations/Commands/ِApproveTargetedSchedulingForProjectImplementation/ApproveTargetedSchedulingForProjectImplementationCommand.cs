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

namespace Batheer.Application.TargetedSchedulingForProjectImplementations.Commands.ApproveTargetedSchedulingForProjectImplementation
{
    public class ApproveTargetedSchedulingForProjectImplementationCommand : IRequest<int>
    {
        public int TargetedSchedulingForProjectImplementationId { get; set; }

    }

    public class ApproveTargetedSchedulingForProjectImplementationCommandHandler : IRequestHandler<ApproveTargetedSchedulingForProjectImplementationCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public ApproveTargetedSchedulingForProjectImplementationCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<ApproveTargetedSchedulingForProjectImplementationCommand> logger, IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(ApproveTargetedSchedulingForProjectImplementationCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.TargetedSchedulingForProjectImplementations
                .Where(w => w.Id == request.TargetedSchedulingForProjectImplementationId)
                .FirstOrDefault();

            entity.TargetedSchedulingForProjectImplementationStatusId = 2;
            entity.ApprovedDate = _dateTime.Now;
            entity.ApprovedBy = _currentUserService.UserId;

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
