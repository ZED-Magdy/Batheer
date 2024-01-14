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

namespace Batheer.Application.SupportingFamilyRequests.Commands.CreateSupportingFamilyRequest
{
    public class CreateSupportingFamilyRequestCommand : IRequest<int>
    {
        public Guid FamilyObjectkey { get; set; }
        public int SupportingFamilyTypeId { get; set; }
        public virtual BankDefaultDataModel BankDefaultData { get; set; }
        public virtual FinanceDataModel FinanceData { get; set; }

        public virtual LoanDataModel LoanData { get; set; }
        public virtual ProjectDataModel ProjectData { get; set; }
        public virtual WorkOnAProjectDataModel WorkOnAProjectData { get; set; }
    }

    public class CreateSupportingFamilyRequestCommandHandler : IRequestHandler<CreateSupportingFamilyRequestCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public CreateSupportingFamilyRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateSupportingFamilyRequestCommand> logger, IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateSupportingFamilyRequestCommand request, CancellationToken cancellationToken)
        {

            var family = _context.Families
                .Where(w => w.objectkey == request.FamilyObjectkey)
                .FirstOrDefault();

            var entity = new SupportingFamilyRequest();
            entity.BankDefaultData = _mapper.Map<BankDefaultDataModel, BankDefaultData>(request.BankDefaultData);
            entity.FinanceData = _mapper.Map<FinanceDataModel, FinanceData>(request.FinanceData);
            entity.LoanData = _mapper.Map<LoanDataModel, LoanData>(request.LoanData);
            entity.ProjectData = _mapper.Map<ProjectDataModel, ProjectData>(request.ProjectData);
            entity.WorkOnAProjectData = _mapper.Map<WorkOnAProjectDataModel, WorkOnAProjectData>(request.WorkOnAProjectData);

            entity.SupportingFamilyTypeId = 1; // الأسر المنتجة // request.SupportingFamilyTypeId;

            family.SupportingFamilyRequest = entity;

            family.SupportingFamilyRequest.RequestStatusId = 1;

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
