﻿using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetById
{
    public class TargetedSchedulingForProjectImplementation : IMapFrom<Domain.TargetedSchedulingForProjectImplementation>
    {
        public int Id { get; set; }

        public int AssociationAffiliatedProjectId { get; set; }
        public int CouncilProjectId { get; set; }
        public string CouncilProjectName { get; set; }
        public string ProjectName { get; set; }

        public string AssociationsAffiliatedWithTheCouncilName { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int TargetedSchedulingForProjectImplementationStatusId { get; set; }
        public string TargetedSchedulingForProjectImplementationStatusName { get; set; }
        public bool IsApproved { get; set; }
        public List<FamilyNeedDetailsDto> FamilyNeedDetails { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<FamilyNeedDetail, FamilyNeedDetailsDto>();

            profile.CreateMap<Domain.TargetedSchedulingForProjectImplementation, TargetedSchedulingForProjectImplementation>()
                .ForMember(d => d.ProjectName, opt => opt.MapFrom(a => a.AssociationAffiliatedProject.ProjectName))
                .ForMember(d => d.CouncilProjectName, opt => opt.MapFrom(a => a.AssociationAffiliatedProject.CouncilProject.Name))
                .ForMember(d => d.IsApproved, opt => opt.MapFrom(a => a.ApprovedDate.HasValue))
                .ForMember(d => d.AssociationsAffiliatedWithTheCouncilName, opt => opt.MapFrom(s => s.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncil.Name))
                .ForMember(d => d.FamilyNeedDetails, opt => opt.MapFrom(s => s.AssociationAffiliatedProject.AssociationAffiliatedProjectFamilyNeedDetails.Select(s => s.FamilyNeedDetail)));

        }

    }

    public class FamilyNeedDetailsDto :
        IMapFrom<FamilyNeedDetail>
    {
        public int Id { get; set; }
        public int FamilyNeedDetailId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FamilyNeedDetail, FamilyNeedDetailsDto>()
                .ForMember(d => d.FamilyNeedDetailId, opt => opt.MapFrom(s => s.Id));
        }
    }
}
