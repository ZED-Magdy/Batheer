using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Families.Queries.GetByObjectkey
{
    public class FamilyDetailsDto : IMapFrom<Family>
    {
        public int Id { get; set; }
        public Guid Objectkey { get; set; }
        public int AssociationAffiliatedProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CouncilProjectName { get; set; }
        public int CouncilProjectId { get; set; }

        public int FamilyId { get; set; }


        public string FullName { get; set; }

        public string FamilyCategoryName { get; set; }
        public int FamilyCategoryId { get; set; }
        public bool HasSupportingFamilyRequest { get; set; }

        public List<FamilyNeedDataDto> FamilyNeeds { get; set; }

        public Guid? FamilyIdentityCardFileObjectKey { get; set; }

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

        public Guid? IdentityFileObjectKey { get; set; }
        public Guid? PersonalPhotoFileObjectKey { get; set; }
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


        #region ContactInformationData
        public string ContactInformation_Email { get; set; }
        public string ContactInformation_Mobile { get; set; }
        public string ContactInformation_PhoneNumber { get; set; }
        public string ContactInformation_Facebook { get; set; }
        public string ContactInformation_Twitter { get; set; }
        public string ContactInformation_Instagram { get; set; }
        public string ContactInformation_Others { get; set; }
        #endregion


        #region ResidencyAddressData
        public bool ResidencyAddressData_IsOutOfTabuk { get; set; }
        public int? ResidencyAddressData_ProvinceId { get; set; }
        public string ResidencyAddressData_Province { get; set; }

        public string ResidencyAddressData_District { get; set; }
        public string ResidencyAddressData_Street { get; set; }
        public string ResidencyAddressData_Others { get; set; }
        public string ResidencyAddressData_LocationOnTheMap { get; set; }
        #endregion

        #region AccommodationData
        public string AccommodationData_AccommodationTypeName { get; set; }
        public string AccommodationData_Others { get; set; }

        #endregion

        #region MonthlyIncomeData
        public string MonthlyIncomeData_MonthlyIncomeName { get; set; }
        #endregion


        #region SocialSecurityData
        public bool SocialSecurityData_AreYouABeneficiaryOfSocialSecurity { get; set; }
        public string SocialSecurityData_Description { get; set; }
        #endregion


        public int OccupationId { get; set; }
        public string OccupationName { get; set; }

        public int MaritalStatusData_StatusId { get; set; }
        public string MaritalStatusData_Others { get; set; }
        public string MonthlyIncomeData_MonthlyIncomeId { get; set; }
        public int AccommodationData_AccommodationTypeId { get; set; }

        public IList<FamilyMemberDto> FamilyMembers { get; set; }

        public GoogleMapValuesDto GoogleMapValuesDto { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FamilyMember, FamilyMemberDto>()
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            .ForMember(d => d.IdentityNo, opt => opt.MapFrom(s => s.PersonalDataForm.IdentityNo))
            .ForMember(d => d.GenderName, opt => opt.MapFrom(s => s.PersonalDataForm.GenderId.ToString()))
            .ForMember(d => d.NationalityName, opt => opt.MapFrom(s => s.PersonalDataForm.Nationality.Name))
            .ForMember(d => d.Objectkey, opt => opt.MapFrom(s => s.objectkey))
            .ForMember(d => d.FullName, opt => opt.MapFrom(s =>
             $"{s.PersonalDataForm.FirstName} {s.PersonalDataForm.FatherName} {s.PersonalDataForm.GrandFatherName} {s.PersonalDataForm.FamilyName}"
            ));


            profile.CreateMap<FamilyNeedData, FamilyNeedDataDto>()
                .ForMember(d => d.FamilyNeedId, opt => opt.MapFrom(s => s.FamilyNeedId))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.FamilyNeed.Name));


            profile.CreateMap<Family, FamilyDetailsDto>()
                .ForMember(d => d.CouncilProjectName, opt => opt.MapFrom(s => s.FamilyRegistrationRequest.CouncilProject.Name))
                .ForMember(d => d.CouncilProjectId, opt => opt.MapFrom(s => s.FamilyRegistrationRequest.CouncilProjectId))
                //.ForMember(d => d.FamilyNeeds, opt => opt.MapFrom(s => s.FamilyRegistrationRequest.FamilyNeedData.Select(s => s.FamilyNeed.Name)))
                .ForMember(d => d.FamilyNeeds, opt => opt.MapFrom(s => s.FamilyRegistrationRequest.FamilyNeedData))

                .ForMember(d => d.FamilyCategoryName, opt => opt.MapFrom(s => s.FamilyRegistrationRequest.FamilyCategory.Name))
                .ForMember(d => d.FamilyCategoryId, opt => opt.MapFrom(s => s.FamilyRegistrationRequest.FamilyCategoryId))

                .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.DateOfBirth))
                .ForMember(d => d.FamilyName, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.FamilyName))
                .ForMember(d => d.FatherName, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.FatherName))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.FirstName))
                .ForMember(d => d.GrandFatherName, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName))
                //.ForMember(d => d.IdentityFilePath, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.IdentityFilePath))
                .ForMember(d => d.IdentityNo, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.IdentityNo))
                .ForMember(d => d.NationalityName, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.Nationality.Name))
                .ForMember(d => d.NationalityId, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.NationalityId))
                //.ForMember(d => d.PersonalPhotoFilePath, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.PersonalPhotoFilePath))
                .ForMember(d => d.PlaceOfBirth, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.PlaceOfBirth))
                .ForMember(d => d.GenderName, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.GenderId.ToString()))
                .ForMember(d => d.GenderId, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.GenderId))

                .ForMember(d => d.EducationalLevelId, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.EducationalData.EducationalLevelId))
                .ForMember(d => d.EducationalLevelName, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.EducationalData.EducationalLevel.Name))
                .ForMember(d => d.HealthStatus_Description, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.HealthStatusData.Description))
                .ForMember(d => d.HealthStatusId, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.HealthStatusData.HealthStatusId))
                .ForMember(d => d.HealthStatusName, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.HealthStatusData.HealthStatus.Name))
                .ForMember(d => d.HealthStatus_Others, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.HealthStatusData.Others))


                .ForMember(d => d.ContactInformation_Email, opt => opt.MapFrom(s => s.ContactInformationData.Email))
                .ForMember(d => d.ContactInformation_Mobile, opt => opt.MapFrom(s => s.ContactInformationData.Mobile))
                .ForMember(d => d.ContactInformation_PhoneNumber, opt => opt.MapFrom(s => s.ContactInformationData.PhoneNumber))
                .ForMember(d => d.ContactInformation_Facebook, opt => opt.MapFrom(s => s.ContactInformationData.Facebook))
                .ForMember(d => d.ContactInformation_Twitter, opt => opt.MapFrom(s => s.ContactInformationData.Twitter))
                .ForMember(d => d.ContactInformation_Instagram, opt => opt.MapFrom(s => s.ContactInformationData.Instagram))
                .ForMember(d => d.ContactInformation_Others, opt => opt.MapFrom(s => s.ContactInformationData.Others))


                .ForMember(d => d.ResidencyAddressData_IsOutOfTabuk, opt => opt.MapFrom(s => s.ResidencyAddressData.IsOutOfTabuk))
                .ForMember(d => d.ResidencyAddressData_ProvinceId, opt => opt.MapFrom(s => s.ResidencyAddressData.ProvinceId))
                .ForMember(d => d.ResidencyAddressData_Province, opt => opt.MapFrom(s => s.ResidencyAddressData.Province))
                .ForMember(d => d.ResidencyAddressData_District, opt => opt.MapFrom(s => s.ResidencyAddressData.District))
                .ForMember(d => d.ResidencyAddressData_Street, opt => opt.MapFrom(s => s.ResidencyAddressData.Street))
                .ForMember(d => d.ResidencyAddressData_Others, opt => opt.MapFrom(s => s.ResidencyAddressData.Others))
                .ForMember(d => d.ResidencyAddressData_LocationOnTheMap, opt => opt.MapFrom(s => s.ResidencyAddressData.LocationOnTheMap))

                .ForMember(d => 
                    d.GoogleMapValuesDto,
                    opt => opt.MapFrom(src => src.ResidencyAddressData.GoogleMapValues ?? new GoogleMapValues()))

                .ForMember(d => d.AccommodationData_AccommodationTypeName, opt => opt.MapFrom(s => s.AccommodationData.AccommodationType.Name))
                .ForMember(d => d.AccommodationData_Others, opt => opt.MapFrom(s => s.AccommodationData.Others))

                .ForMember(d => d.MonthlyIncomeData_MonthlyIncomeName, opt => opt.MapFrom(s => s.MonthlyIncomeData.MonthlyIncome.Name))


                .ForMember(d => d.SocialSecurityData_AreYouABeneficiaryOfSocialSecurity, opt => opt.MapFrom(s => s.SocialSecurityData.AreYouABeneficiaryOfSocialSecurity))
                .ForMember(d => d.SocialSecurityData_Description, opt => opt.MapFrom(s => s.SocialSecurityData.Description))




                .ForMember(d => d.HasSupportingFamilyRequest, opt => opt.MapFrom(s => s.SupportingFamilyRequest != null))
                .ForMember(d => d.FullName, opt => opt.MapFrom(s =>
                 $"{s.ResponsibleFamilyMember.PersonalDataForm.FirstName} {s.ResponsibleFamilyMember.PersonalDataForm.FatherName} {s.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName} {s.ResponsibleFamilyMember.PersonalDataForm.FamilyName}"
                ))

                .ForMember(d => d.FamilyIdentityCardFileObjectKey, opt => opt.MapFrom(s => s.FamilyIdentityCardFile.ObjectKey))


                .ForMember(d => d.FamilyMembers,
                        opt => opt.MapFrom(s => s.FamilyMembers))

                .ForMember(d => d.IdentityFileObjectKey, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.IdentityFile.ObjectKey))
                .ForMember(d => d.PersonalPhotoFileObjectKey, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.PersonalDataForm.PersonalPhotoFile.ObjectKey))
                .ForMember(d => d.Objectkey, opt => opt.MapFrom(s => s.objectkey))

                .ForMember(d => d.OccupationId, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.OccupationData.OccupationId))
                .ForMember(d => d.OccupationName, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.OccupationData.Occupation.Name))

                .ForMember(d => d.MaritalStatusData_StatusId, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.MaritalStatusData.MaritalStatusId))
                .ForMember(d => d.MaritalStatusData_Others, opt => opt.MapFrom(s => s.ResponsibleFamilyMember.MaritalStatusData.Others))

                 .ForMember(d => d.AccommodationData_AccommodationTypeId, opt => opt.MapFrom(s => s.AccommodationData.AccommodationTypeId))
                 .ForMember(d => d.MonthlyIncomeData_MonthlyIncomeId, opt => opt.MapFrom(s => s.MonthlyIncomeData.MonthlyIncomeId))
            ;


        }



        public class FamilyMemberDto
        {
            public int Id { get; set; }
            public Guid Objectkey { get; set; }
            public string FullName { get; set; }
            public string IdentityNo { get; set; }
            public string GenderName { get; set; }
            public string NationalityName { get; set; }
        }

        public class FamilyNeedDataDto
        {
            public int Id { get; set; }
            public int FamilyNeedId { get; set; }
            public string Name { get; set; }
        }
    }
}
