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

namespace Batheer.Application.AssociationAffiliatedProjects.Commands.DeleteAssociationAffiliatedProject
{
    public class DeleteAssociationAffiliatedProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteAssociationAffiliatedProjectCommandHandler : IRequestHandler<DeleteAssociationAffiliatedProjectCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteAssociationAffiliatedProjectCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<DeleteAssociationAffiliatedProjectCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteAssociationAffiliatedProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.AssociationAffiliatedProjects
                .Include(i=> i.AssociationAffiliatedProjectFamilyNeedDetails)
                .Where(w=> w.Id == request.Id)
                .FirstOrDefault();

            _context.AssociationAffiliatedProjectFamilyNeedDetails.RemoveRange(entity.AssociationAffiliatedProjectFamilyNeedDetails);
            _context.AssociationAffiliatedProjects.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
