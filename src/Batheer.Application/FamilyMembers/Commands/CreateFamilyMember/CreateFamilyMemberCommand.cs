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

namespace Batheer.Application.FamilyMembers.Commands.CreateFamilyMember
{
    public class CreateFamilyMemberCommand : IRequest<int>
    {
        public int FamilyId { get; set; }
        public virtual PersonalDataFormModel PersonalDataForm { get; set; }
        public virtual EducationalDataModel EducationalData { get; set; }

        public virtual HealthStatusDataModel HealthStatusData { get; set; }
    }

    public class CreateFamilyMemberCommandHandler : IRequestHandler<CreateFamilyMemberCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public CreateFamilyMemberCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateFamilyMemberCommand> logger, IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateFamilyMemberCommand request, CancellationToken cancellationToken)
        {

            var family = _context.Families
                .Include(i => i.FamilyMembers)
                .Where(w => w.Id == request.FamilyId)
                .FirstOrDefault();

            var entity = new FamilyMember();
            entity.PersonalDataForm = _mapper.Map<PersonalDataFormModel, PersonalDataForm>(request.PersonalDataForm);
            entity.EducationalData = _mapper.Map<EducationalDataModel, EducationalData>(request.EducationalData);
            entity.HealthStatusData = _mapper.Map<HealthStatusDataModel, HealthStatusData>(request.HealthStatusData);

            entity.objectkey = Guid.NewGuid();

            family.FamilyMembers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
