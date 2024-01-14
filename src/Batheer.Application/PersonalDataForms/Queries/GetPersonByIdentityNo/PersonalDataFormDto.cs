using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AuthenticationUsers;
using System;
using static Batheer.Domain.AuthenticationUsers.User;

namespace Batheer.Application.PersonalDataForms.Queries.GetPersonByIdentityNo
{
    public class PersonalDataFormDto : IMapFrom<PersonalDataForm>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }

        public string IdentityNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int GenderId { get; set; }
        public int NationalityId { get; set; }
        
        public int? IdentityFileId { get; set; }
       
        public int? PersonalPhotoFileId { get; set; }

        public bool IsInFamilyMembers { get; set; }

        public Guid? FamilyMemberObjectkey { get; set; }
        public bool IsInResponsibleFamilyMembers { get; set; }

        public Guid FamilyObjectkey { get; set; }

        public string AssociationsAffiliatedWithTheCouncilName { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<User, UserDto>();
        //}
    }
}
