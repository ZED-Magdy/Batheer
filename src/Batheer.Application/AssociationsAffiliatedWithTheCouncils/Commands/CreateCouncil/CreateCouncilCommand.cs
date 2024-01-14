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

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncils.Commands.CreateCouncil
{
    public class CreateCouncilCommand : IRequest<int>
    {
        public string Name { get; set; }
        public AssociationsAffiliatedWithTheCouncil.CouncilCategories CouncilCategory { get; set; }
    }

    public class CreateCouncilCommandHandler : IRequestHandler<CreateCouncilCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public CreateCouncilCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateCouncilCommand> logger, IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateCouncilCommand request, CancellationToken cancellationToken)
        {
            var entity = new AssociationsAffiliatedWithTheCouncil()
            {
                Name = request.Name,
                CouncilCategory = request.CouncilCategory,
            };


            _context.AssociationsAffiliatedWithTheCouncils.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }

    }

}
