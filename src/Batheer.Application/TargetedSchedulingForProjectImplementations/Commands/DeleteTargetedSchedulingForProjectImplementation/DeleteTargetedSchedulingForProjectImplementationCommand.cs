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

namespace Batheer.Application.TargetedSchedulingForProjectImplementations.Commands.DeleteTargetedSchedulingForProjectImplementation
{
    public class DeleteTargetedSchedulingForProjectImplementationCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteTargetedSchedulingForProjectImplementationCommandHandler : IRequestHandler<DeleteTargetedSchedulingForProjectImplementationCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteTargetedSchedulingForProjectImplementationCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<DeleteTargetedSchedulingForProjectImplementationCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteTargetedSchedulingForProjectImplementationCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.TargetedSchedulingForProjectImplementations.Find(request.Id);

            _context.TargetedSchedulingForProjectImplementations.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
