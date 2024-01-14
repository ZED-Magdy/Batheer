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

namespace Batheer.Application.TargetedSchedulingForProjectImplementations.Commands.UpdateTargetedSchedulingForProjectImplementation
{
    public class UpdateTargetedSchedulingForProjectImplementationCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TargetedSchedulingForProjectImplementationStatusId { get; set; }

    }

    public class UpdateTargetedSchedulingForProjectImplementationCommandHandler : IRequestHandler<UpdateTargetedSchedulingForProjectImplementationCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateTargetedSchedulingForProjectImplementationCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<UpdateTargetedSchedulingForProjectImplementationCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateTargetedSchedulingForProjectImplementationCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.TargetedSchedulingForProjectImplementations.Find(request.Id);


            entity.FromDate = request.FromDate;
            entity.ToDate = request.ToDate;
            entity.TargetedSchedulingForProjectImplementationStatusId = request.TargetedSchedulingForProjectImplementationStatusId;


            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
