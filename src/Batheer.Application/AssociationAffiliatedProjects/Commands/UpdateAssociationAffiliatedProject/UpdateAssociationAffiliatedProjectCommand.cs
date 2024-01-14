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

namespace Batheer.Application.AssociationAffiliatedProjects.Commands.UpdateAssociationAffiliatedProject
{
    public class UpdateAssociationAffiliatedProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int CouncilProjectId { get; set; }

        public string AboutTheProject { get; set; }
        public string Notes { get; set; }
        public string ProjectName { get; set; }
        public List<int> FamilyNeedDetails { get; set; }

    }

    public class UpdateAssociationAffiliatedProjectCommandHandler : IRequestHandler<UpdateAssociationAffiliatedProjectCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateAssociationAffiliatedProjectCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<UpdateAssociationAffiliatedProjectCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateAssociationAffiliatedProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.AssociationAffiliatedProjects
                .Include(i => i.AssociationAffiliatedProjectFamilyNeedDetails)
                .ThenInclude(i => i.FamilyNeedDetail)
                .Where(w => w.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);


            entity.AboutTheProject = request.AboutTheProject;
            entity.CouncilProjectId = request.CouncilProjectId;
            entity.Notes = request.Notes;
            entity.ProjectName = request.ProjectName;


            entity.AssociationAffiliatedProjectFamilyNeedDetails
                .ToList()
                .ForEach(e =>
            {

                var isOldItemExistsInNewList = request.FamilyNeedDetails.Any(familyNeedDetailId => familyNeedDetailId == e.FamilyNeedDetailId);
                if (isOldItemExistsInNewList == false)
                {
                    // remove old value
                    //entity.AssociationAffiliatedProjectFamilyNeedDetails.Remove(e);
                    _context.AssociationAffiliatedProjectFamilyNeedDetails.Remove(e);
                }
            });

            request.FamilyNeedDetails?.ForEach(familyNeedDetailId =>
            {
                var isNewItemExistsInOldList = entity.AssociationAffiliatedProjectFamilyNeedDetails.Any(a => a.FamilyNeedDetailId == familyNeedDetailId);

                if (isNewItemExistsInOldList == false)
                {
                    // add new item
                    entity.AssociationAffiliatedProjectFamilyNeedDetails.Add(new AssociationAffiliatedProjectFamilyNeedDetail()
                    {
                        FamilyNeedDetailId = familyNeedDetailId,
                    });
                }
            });
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
