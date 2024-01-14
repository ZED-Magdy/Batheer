using AutoMapper;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncilInfos.Commands.CreateAssociationsAffiliatedWithTheCouncilInfo
{
    public class SaveAssociationsAffiliatedWithTheCouncilInfoCommand : IRequest<int>
    {
        public string President_Name { get; set; }
        public string President_Mobile { get; set; }
        public string VicePresident_Mobile { get; set; }
        public string VicePresident_Name { get; set; }
        public string Manager_Mobile { get; set; }
        public string Manager_Name { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime? MembershipDate { get; set; }
        public DateTime? MembershipEndDate { get; set; }
        public string EmployeesCount { get; set; }
        public string MembersCount { get; set; }
        public string GeneralMembersCount { get; set; }
        public string LocationOnGoogleMap { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public List<int> ActivityTypes { get; set; } = new();
        public int? ClassificationId { get; set; }

        public int TownId { get; set; }
    }

    public class CreateAssociationsAffiliatedWithTheCouncilInfoCommandHandler : IRequestHandler<SaveAssociationsAffiliatedWithTheCouncilInfoCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;

        public CreateAssociationsAffiliatedWithTheCouncilInfoCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<SaveAssociationsAffiliatedWithTheCouncilInfoCommand> logger, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(SaveAssociationsAffiliatedWithTheCouncilInfoCommand request, CancellationToken cancellationToken)
        {
            AssociationsAffiliatedWithTheCouncilInfo entity;

            var associationsAffiliatedWithTheCouncil = await _context.AssociationsAffiliatedWithTheCouncils
                .Include(i => i.AssociationsAffiliatedWithTheCouncilInfo)
                .ThenInclude(i => i.ActivityTypes)
                .Where(w => w.Id == _currentUserService.CouncilId)
                .FirstOrDefaultAsync();

            entity = associationsAffiliatedWithTheCouncil.AssociationsAffiliatedWithTheCouncilInfo;
            if (entity is null)
            {
                entity = new AssociationsAffiliatedWithTheCouncilInfo();
                _context.AssociationsAffiliatedWithTheCouncilInfos.Add(entity);
                //associationsAffiliatedWithTheCouncil.AssociationsAffiliatedWithTheCouncilInfoId = entity.Id;

                entity.objectkey = Guid.NewGuid();

                request.ActivityTypes.ForEach(at_id =>
                {
                    entity.ActivityTypes.Add(new AssociationsAffiliatedWithTheCouncilInfoActivityType()
                    {
                        ActivityTypeId = at_id
                    });
                });
            }
            else
            {
                entity.ActivityTypes
                .ToList()
                .ForEach(e =>
                {
                    var isOldItemExistsInNewList = request.ActivityTypes.Any(activityTypeId => activityTypeId == e.ActivityTypeId);
                    if (isOldItemExistsInNewList == false)
                    {
                        // remove old value
                        _context.AssociationsAffiliatedWithTheCouncilInfoActivityTypes.Remove(e);
                    }
                });

                request.ActivityTypes.ForEach(activityTypeId =>
                {
                    var isNewItemExistsInOldList = entity.ActivityTypes.Any(a => a.ActivityTypeId == activityTypeId);

                    if (isNewItemExistsInOldList == false)
                    {
                        // add new item
                        entity.ActivityTypes.Add(new AssociationsAffiliatedWithTheCouncilInfoActivityType()
                        {
                            ActivityTypeId = activityTypeId,
                        });
                    }
                });
            }

            entity.ClassificationId = request.ClassificationId;
            entity.ContactNumber = request.ContactNumber;
            entity.Email = request.Email;
            entity.EmployeesCount = request.EmployeesCount;
            entity.LicenseNumber = request.LicenseNumber;
            entity.LocationOnGoogleMap = request.LocationOnGoogleMap;
            entity.Manager_Mobile = request.Manager_Mobile;
            entity.Manager_Name = request.Manager_Name;
            entity.MembersCount = request.MembersCount;
            entity.GeneralMembersCount = request.GeneralMembersCount;
            entity.MembershipDate = request.MembershipDate;
            entity.MembershipEndDate = request.MembershipEndDate;
            entity.President_Mobile = request.President_Mobile;
            entity.President_Name = request.President_Name;
            entity.VicePresident_Mobile = request.VicePresident_Mobile;
            entity.VicePresident_Name = request.VicePresident_Name;
            entity.WebsiteUrl = request.WebsiteUrl;
            entity.TownId = request.TownId;



            await _context.SaveChangesAsync(cancellationToken);

            if (associationsAffiliatedWithTheCouncil.AssociationsAffiliatedWithTheCouncilInfo is null)
            {
                associationsAffiliatedWithTheCouncil.AssociationsAffiliatedWithTheCouncilInfoId = entity.Id;
            }
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
