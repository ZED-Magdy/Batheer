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

namespace Batheer.Application.FamilyMembers.Commands.UpdateFamilyMember
{
    public class UpdateFamilyMemberCommand : IRequest<int>
    {
        public Guid Objectkey { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int GenderId { get; set; }

        public int NationalityId { get; set; }


        public int HealthStatusId { get; set; }

        public string HealthStatus_Others { get; set; }

        public string HealthStatus_Description { get; set; }


        public int EducationalLevelId { get; set; }

    }

    public class UpdateFamilyMemberCommandHandler : IRequestHandler<UpdateFamilyMemberCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public UpdateFamilyMemberCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<UpdateFamilyMemberCommand> logger, IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(UpdateFamilyMemberCommand request, CancellationToken cancellationToken)
        {

            var familyMember = _context.FamilyMembers
                .Include(i => i.HealthStatusData)
                .Include(i => i.EducationalData)
                .Include(i => i.PersonalDataForm)
                .Where(w => w.objectkey == request.Objectkey)
                .FirstOrDefault();


            familyMember.EducationalData.EducationalLevelId = request.EducationalLevelId;
            familyMember.HealthStatusData.Description = request.HealthStatus_Description;
            familyMember.HealthStatusData.HealthStatusId = request.HealthStatusId;
            familyMember.HealthStatusData.Others = request.HealthStatus_Others;
            familyMember.PersonalDataForm.DateOfBirth = request.DateOfBirth;
            familyMember.PersonalDataForm.FamilyName = request.FamilyName;
            familyMember.PersonalDataForm.FatherName = request.FatherName;
            familyMember.PersonalDataForm.FirstName = request.FirstName;
            familyMember.PersonalDataForm.GenderId = request.GenderId;
            familyMember.PersonalDataForm.GrandFatherName = request.GrandFatherName;
            familyMember.PersonalDataForm.NationalityId = request.NationalityId;
            familyMember.PersonalDataForm.PlaceOfBirth = request.PlaceOfBirth;




            await _context.SaveChangesAsync(cancellationToken);

            return familyMember.Id;
        }

    }

}
