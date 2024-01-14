using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.FamilyMembers.Queries.GetFamilyMemberByObjectkey
{
    public class FamilyMemberDto : IMapFrom<FamilyMember>
    {
        public int Id { get; set; }
        public Guid Objectkey { get; set; }

        public int FamilyId { get; set; }
        public Guid FamilyObjectkey { get; set; }
        public int FamilyRegistrationRequestId { get; set; }

        #region PersonalDataForm

        public int PersonalDataFormId { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }

        public string IdentityNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string GenderName { get; set; }
        public int GenderId { get; set; }

        public int NationalityId { get; set; }
        public string NationalityName { get; set; }

        public Guid IdentityFileObjectKey { get; set; }
        public Guid PersonalPhotoFileObjectKey { get; set; }
        #endregion

        #region HealthStatusData

        public int HealthStatusDataId { get; set; }

        public int HealthStatusId { get; set; }
        public string HealthStatusName { get; set; }

        public string HealthStatus_Others { get; set; }

        /// <summary>
        /// نوع المرض أو الإعاقة إن وجد
        /// </summary>
        public string HealthStatus_Description { get; set; }

        #endregion

        #region EducationalData

        public int EducationalDataId { get; set; }
        public int EducationalLevelId { get; set; }
        public string EducationalLevelName { get; set; }

        #endregion

        public string OccupationName { get; set; }
        public int OccupationId { get; set; }
        public string MaritalStatusData_StatusName { get; set; }
        public string MaritalStatusData_StatusId { get; set; }
        public string MaritalStatusData_Others { get; set; }
        public void Mapping(Profile profile)
        {

            profile.CreateMap<FamilyMember, FamilyMemberDto>()
                .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(s => s.PersonalDataForm.DateOfBirth))
                .ForMember(d => d.FamilyName, opt => opt.MapFrom(s => s.PersonalDataForm.FamilyName))
                .ForMember(d => d.FatherName, opt => opt.MapFrom(s => s.PersonalDataForm.FatherName))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.PersonalDataForm.FirstName))
                .ForMember(d => d.GrandFatherName, opt => opt.MapFrom(s => s.PersonalDataForm.GrandFatherName))
                //.ForMember(d => d.IdentityFilePath, opt => opt.MapFrom(s => s.PersonalDataForm.IdentityFilePath))
                .ForMember(d => d.IdentityNo, opt => opt.MapFrom(s => s.PersonalDataForm.IdentityNo))
                .ForMember(d => d.NationalityName, opt => opt.MapFrom(s => s.PersonalDataForm.Nationality.Name))
                .ForMember(d => d.NationalityId, opt => opt.MapFrom(s => s.PersonalDataForm.NationalityId))
                //.ForMember(d => d.PersonalPhotoFilePath, opt => opt.MapFrom(s => s.PersonalDataForm.PersonalPhotoFilePath))
                .ForMember(d => d.PlaceOfBirth, opt => opt.MapFrom(s => s.PersonalDataForm.PlaceOfBirth))
                .ForMember(d => d.GenderName, opt => opt.MapFrom(s => s.PersonalDataForm.GenderId.ToString()))
                .ForMember(d => d.GenderId, opt => opt.MapFrom(s => s.PersonalDataForm.GenderId))
                .ForMember(d => d.NationalityName, opt => opt.MapFrom(s => s.PersonalDataForm.Nationality.Name))

                .ForMember(d => d.EducationalLevelId, opt => opt.MapFrom(s => s.EducationalData.EducationalLevelId))
                .ForMember(d => d.EducationalLevelName, opt => opt.MapFrom(s => s.EducationalData.EducationalLevel.Name))
                .ForMember(d => d.HealthStatus_Description, opt => opt.MapFrom(s => s.HealthStatusData.Description))
                .ForMember(d => d.HealthStatusId, opt => opt.MapFrom(s => s.HealthStatusData.HealthStatusId))
                .ForMember(d => d.HealthStatusName, opt => opt.MapFrom(s => s.HealthStatusData.HealthStatus.Name))
                .ForMember(d => d.HealthStatus_Others, opt => opt.MapFrom(s => s.HealthStatusData.Others))

                .ForMember(d => d.FamilyId, opt => opt.MapFrom(s => s.Family.Id))
                // .ForMember(d => d.FamilyRegistrationRequestId, opt => opt.MapFrom(s => s.Family.))

                .ForMember(d => d.FamilyObjectkey, opt => opt.MapFrom(s => s.Family.objectkey))
                .ForMember(d => d.IdentityFileObjectKey, opt => opt.MapFrom(s => s.PersonalDataForm.IdentityFile.ObjectKey))
                .ForMember(d => d.PersonalPhotoFileObjectKey, opt => opt.MapFrom(s => s.PersonalDataForm.PersonalPhotoFile.ObjectKey))

                .ForMember(d => d.OccupationId, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.OccupationData.OccupationId))
                .ForMember(d => d.OccupationName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.OccupationData.Occupation.Name))
                .ForMember(d => d.MaritalStatusData_Others, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.MaritalStatusData.Others))
                .ForMember(d => d.MaritalStatusData_StatusId, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.MaritalStatusData.MaritalStatusId))
                .ForMember(d => d.MaritalStatusData_StatusName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.MaritalStatusData.MaritalStatus.Name))
            ;
        }
    }
}
