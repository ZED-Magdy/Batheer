using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.ExcludeIdentityNumbers.Queries.GetExcludeIdentityNumbers
{
    public class ExcludeIdentityNumberDto : IMapFrom<Domain.ExcludeIdentityNumber>
    {
        public int Id { get; set; }
        public string CouncilName { get; set; }
        public string IdentityNo { get; set; }
        public string Notes { get; set; }




        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {FatherName} {GrandFatherName} {FamilyName}";
            }
        }

        public bool IsFamilyMember { get; set; }
        public Guid? FamilyMemberObjectkey { get; set; }
        public Guid FamilyObjectkey { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.ExcludeIdentityNumber, ExcludeIdentityNumberDto>();

        }

    }
}
