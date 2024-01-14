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

namespace Batheer.Application.TargetedSchedulingForProjectImplementations.Commands.CreateTargetedSchedulingForProjectImplementation
{
    public class CreateTargetedSchedulingForProjectImplementationCommand : IRequest<int>
    {
        public int AssociationAffiliatedProjectId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TargetedSchedulingForProjectImplementationStatusId { get; set; }

    }

    public class CreateTargetedSchedulingForProjectImplementationCommandHandler : IRequestHandler<CreateTargetedSchedulingForProjectImplementationCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateTargetedSchedulingForProjectImplementationCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateTargetedSchedulingForProjectImplementationCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateTargetedSchedulingForProjectImplementationCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.TargetedSchedulingForProjectImplementations.Add(new TargetedSchedulingForProjectImplementation());

            entity.CurrentValues.SetValues(request);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Entity.Id;
        }

    }

}
