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

namespace Batheer.Application.AssociationAffiliatedProjects.Commands.CreateAssociationAffiliatedProject
{
    public class CreateAssociationAffiliatedProjectCommand : IRequest<int>
    {
        public int CouncilProjectId { get; set; }
        public int AssociationsAffiliatedWithTheCouncilId { get; set; }

        public string AboutTheProject { get; set; }
        public string Notes { get; set; }
        public string ProjectName { get; set; }
        public List<int> FamilyNeedDetails { get; set; }
    }

    public class CreateAssociationAffiliatedProjectCommandHandler : IRequestHandler<CreateAssociationAffiliatedProjectCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateAssociationAffiliatedProjectCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateAssociationAffiliatedProjectCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateAssociationAffiliatedProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.AssociationAffiliatedProjects.Add(new AssociationAffiliatedProject());

            entity.CurrentValues.SetValues(request);

            request.FamilyNeedDetails?.ForEach(familyNeedDetailId =>
            {
                entity.Entity.AssociationAffiliatedProjectFamilyNeedDetails.Add(new AssociationAffiliatedProjectFamilyNeedDetail()
                {
                    FamilyNeedDetailId = familyNeedDetailId,
                });
            });

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Entity.Id;
        }

    }

}
