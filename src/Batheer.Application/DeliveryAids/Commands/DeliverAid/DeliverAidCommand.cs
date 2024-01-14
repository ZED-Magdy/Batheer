using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.DeliveryAids.Commands.DeliverAid
{
    public class DeliverAidCommand : IRequest<int>
    {
        public int AssociationAffiliatedId { get; set; }
        public int FamilyId { get; set; }
        public int TheIntendedBeneficiariesOfTheScheduledAssociationProjectId { get; set; }
    }

    public class DeliverAidCommandHandler : IRequestHandler<DeliverAidCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public DeliverAidCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<DeliverAidCommand> logger, IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(DeliverAidCommand request, CancellationToken cancellationToken)
        {
            //var spliter = request.ReceivedCode.Split("-").ToList();
            //var familyId = ParseInt(spliter.ElementAt(0));
            //var theIntendedBeneficiariesOfTheScheduledAssociationProjectId = ParseInt(spliter.ElementAt(1));


            //var entity = await _context
            //  .TheIntendedBeneficiariesOfTheScheduledAssociationProjects
            //  .Where(w => w.Id == theIntendedBeneficiariesOfTheScheduledAssociationProjectId)
            //  .Where(w => w.FamilyId == familyId)
            //  .Where(w => w.TargetedSchedulingForProjectImplementation.AssociationAffiliatedProject.CouncilProjectId == request.AssociationAffiliatedId)
            //  .FirstAsync(cancellationToken);


            var entity = await _context
               .TheIntendedBeneficiariesOfTheScheduledAssociationProjects
               .Include(i => i.Family.FamilyRegistrationRequest)
               .Where(w => w.Id == request.TheIntendedBeneficiariesOfTheScheduledAssociationProjectId)
               .Where(w => w.FamilyId == request.FamilyId)
               .Where(w => w.TargetedSchedulingForProjectImplementation.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncilId == request.AssociationAffiliatedId)
               .FirstAsync(cancellationToken);


            entity.ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject = new ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject()
            {
                CreatedBy = _currentUserService.UserId,
                CreatedDate = _dateTime.Now,
                ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatusId = 1,
                TheIntendedBeneficiariesOfTheScheduledAssociationProjectId = entity.Id,
            };

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }


        private int ParseInt(string value, int defaultIntValue = 0)
        {

            if (value is null)
                return defaultIntValue;

            int parsedInt;
            if (int.TryParse(value, out parsedInt))
            {
                return parsedInt;
            }

            return defaultIntValue;
        }

    }

}
