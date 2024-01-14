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

namespace Batheer.Application.TheIntendedBeneficiaries.Commands.AssignRequest
{
    public class AssignRequestCommand : IRequest<int>
    {
        public int FamilyId { get; set; }
        public int TargetedSchedulingForProjectImplementationId { get; set; }

    }

    public class AssignRequestCommandHandler : IRequestHandler<AssignRequestCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AssignRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<AssignRequestCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AssignRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.TargetedSchedulingForProjectImplementations.Find(request.TargetedSchedulingForProjectImplementationId);

            entity.TheIntendedBeneficiariesOfTheScheduledAssociationProjects.Add(new TheIntendedBeneficiariesOfTheScheduledAssociationProject()
            {
                FamilyId = request.FamilyId,
                TargetedSchedulingForProjectImplementationId = request.TargetedSchedulingForProjectImplementationId,
                //BaseRequestId = request.BaseRequestId,
            });
            try
            {

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw;
            }

            return entity.Id;
        }

    }

}
