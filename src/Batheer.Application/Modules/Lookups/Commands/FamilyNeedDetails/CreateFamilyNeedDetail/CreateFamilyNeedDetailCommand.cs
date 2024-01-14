using AutoMapper;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.Lookups.Commands.FamilyNeedDetails.CreateFamilyNeedDetail
{
    public class CreateFamilyNeedDetailCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int FamilyNeedId { get; set; }

        public class CreateFamilyNeedDetailCommandHandler : IRequestHandler<CreateFamilyNeedDetailCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<CreateFamilyNeedDetailCommand> _logger;

            public CreateFamilyNeedDetailCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateFamilyNeedDetailCommand> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<int> Handle(CreateFamilyNeedDetailCommand request, CancellationToken cancellationToken)
            {
                var entity = new FamilyNeedDetail();
                entity.FamilyNeedId = request.FamilyNeedId;
                entity.Name = request.Name;

                _context.FamilyNeedDetails.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
