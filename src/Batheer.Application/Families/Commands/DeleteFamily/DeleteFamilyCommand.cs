using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Models.RequestForms;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Families.Commands.DeleteFamily
{
    public class DeleteFamilyCommand : IRequest<int>
    {
        public Guid Objectkey { get; set; }
        public string DeleteNotes { get; set; }
    }

    public class DeleteFamilyCommandHandler : IRequestHandler<DeleteFamilyCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteFamilyCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<DeleteFamilyCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteFamilyCommand request, CancellationToken cancellationToken)
        {
            var family = _context.Families
               .Where(w => w.objectkey == request.Objectkey)
               .FirstOrDefault();

            family.DeleteNotes = request.DeleteNotes;
            _context.Families.Remove(family);


            await _context.SaveChangesAsync(cancellationToken);

            return int.MinValue;
        }

    }

}
