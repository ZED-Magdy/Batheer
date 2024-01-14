using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Models.RequestForms;
using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.FamilyMembers.Commands.DeleteFamilyMember
{
    public class DeleteFamilyMemberCommand : IRequest<int>
    {
        public Guid Objectkey { get; set; }
        public string DeleteNotes { get; set; }


        public DeleteFamilyMemberCommand() { }
        public DeleteFamilyMemberCommand(Guid objectkey)
        {
            Objectkey = objectkey;
        }
    }

    public class DeleteFamilyMemberCommandHandler : IRequestHandler<DeleteFamilyMemberCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public DeleteFamilyMemberCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<DeleteFamilyMemberCommand> logger, IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(DeleteFamilyMemberCommand request, CancellationToken cancellationToken)
        {

            var familyMember = _context
                .FamilyMembers
                .Where(w => w.objectkey == request.Objectkey)
                .FirstOrDefault();


            familyMember.DeleteNotes = request.DeleteNotes;

            _context.FamilyMembers.Remove(familyMember);

            await _context.SaveChangesAsync(cancellationToken);

            return int.MinValue;
        }

    }

}
