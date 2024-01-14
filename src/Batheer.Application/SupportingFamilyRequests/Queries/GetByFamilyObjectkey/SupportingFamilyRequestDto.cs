using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.SupportingFamilyRequests.Queries.GetByFamilyObjectkey
{
    public class SupportingFamilyRequestDto : IMapFrom<SupportingFamilyRequest>
    {
        public int Id { get; set; }

        public int FamilyId { get; set; }
        public Guid FamilyObjectkey { get; set; }
        public int SupportingFamilyTypeId { get; set; }
        public string SupportingFamilyTypeName { get; set; }
        public int BankDefaultDataId { get; set; }
        public bool IsThereABankDefault { get; set; }

        public int FinanceDataId { get; set; }

        public int FinanceTypeId { get; set; }
        public string FinanceTypeName { get; set; }
        public int? ProducedFamilyProductId { get; set; }
        public string ProducedFamilyProductName { get; set; }

        public int LoanDataId { get; set; }
        public int LoanTypeId { get; set; }
        public string LoanTypeName { get; set; }

        public string LoanData_Others { get; set; }

        public bool DoYouHaveLoansOrOtherObligations { get; set; }

        public string LoanData_Description { get; set; }

        public int ProjectDataId { get; set; }
        public int EstimatedProjectCostId { get; set; }
        public string EstimatedProjectCostName { get; set; }

        public string ProjectData_Others { get; set; }

        public string AboutTheProject { get; set; }


        public string WhatAreTheObstaclesFacingTheProject { get; set; }

        public bool AreYouFreeAndReadyToWorkOnAproject { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<SupportingFamilyRequest, SupportingFamilyRequestDto>()
                 .ForMember(d => d.SupportingFamilyTypeName, opt => opt.MapFrom(s => s.SupportingFamilyType.Name))
                 .ForMember(d => d.IsThereABankDefault, opt => opt.MapFrom(s => s.BankDefaultData.IsThereABankDefault))
                 .ForMember(d => d.FinanceTypeId, opt => opt.MapFrom(s => s.FinanceData.FinanceTypeId))
                 .ForMember(d => d.FinanceTypeName, opt => opt.MapFrom(s => s.FinanceData.FinanceType.Name))
                 .ForMember(d => d.ProducedFamilyProductId, opt => opt.MapFrom(s => s.FinanceData.ProducedFamilyProductId))
                 .ForMember(d => d.ProducedFamilyProductName, opt => opt.MapFrom(s => s.FinanceData.ProducedFamilyProduct.Name))
                 .ForMember(d => d.LoanTypeId, opt => opt.MapFrom(s => s.LoanData.LoanTypeId))
                 .ForMember(d => d.LoanTypeName, opt => opt.MapFrom(s => s.LoanData.LoanType.Name))
                 .ForMember(d => d.LoanData_Others, opt => opt.MapFrom(s => s.LoanData.Others))
                 .ForMember(d => d.DoYouHaveLoansOrOtherObligations, opt => opt.MapFrom(s => s.LoanData.DoYouHaveLoansOrOtherObligations))
                 .ForMember(d => d.LoanData_Description, opt => opt.MapFrom(s => s.LoanData.Description))
                 .ForMember(d => d.EstimatedProjectCostId, opt => opt.MapFrom(s => s.ProjectData.EstimatedProjectCostId))
                 .ForMember(d => d.EstimatedProjectCostName, opt => opt.MapFrom(s => s.ProjectData.EstimatedProjectCost.Name))
                 .ForMember(d => d.ProjectData_Others, opt => opt.MapFrom(s => s.ProjectData.Others))
                 .ForMember(d => d.AboutTheProject, opt => opt.MapFrom(s => s.ProjectData.AboutTheProject))
                 .ForMember(d => d.WhatAreTheObstaclesFacingTheProject, opt => opt.MapFrom(s => s.ProjectData.WhatAreTheObstaclesFacingTheProject))
                 .ForMember(d => d.AreYouFreeAndReadyToWorkOnAproject, opt => opt.MapFrom(s => s.WorkOnAProjectData.AreYouFreeAndReadyToWorkOnAproject))
                 .ForMember(d=> d.FamilyObjectkey, opt=> opt.MapFrom(s=> s.Family.objectkey))
                 ;
;
        }
    }
}
