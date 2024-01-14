using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Mappings;
using Batheer.Application.Common.Models;
using Batheer.Application.Common.Models.RequestForms;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Families.Commands.UpdateFamily
{
    public class UpdateFamilyCommand : IRequest<int>
    {
        public Guid Objectkey { get; set; }

        public int FamilyCategoryId { get; set; }

        public List<int> FamilyNeedIds { get; set; }


        #region PersonalDataForm

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }

        public string IdentityNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int GenderId { get; set; }

        public int NationalityId { get; set; }
        #endregion

        #region HealthStatusData

        public int HealthStatusId { get; set; }
        public string HealthStatusName { get; set; }

        public string HealthStatus_Others { get; set; }

        /// <summary>
        /// نوع المرض أو الإعاقة إن وجد
        /// </summary>
        public string HealthStatus_Description { get; set; }

        #endregion

        #region EducationalData

        public int EducationalLevelId { get; set; }

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
        public int AccommodationData_AccommodationTypeId { get; set; }
        public string AccommodationData_Others { get; set; }

        #endregion

        #region MonthlyIncomeData
        public int MonthlyIncomeData_MonthlyIncomeId { get; set; }
        public string MonthlyIncomeData_MonthlyIncomeName { get; set; }
        #endregion


        #region SocialSecurityData
        public bool SocialSecurityData_AreYouABeneficiaryOfSocialSecurity { get; set; }
        public string SocialSecurityData_Description { get; set; }
        #endregion
        public int OccupationId { get; set; }
        public int MaritalStatusData_StatusId { get; set; }
        public string MaritalStatusData_StatusName { get; set; }
        public string MaritalStatusData_Others { get; set; }

        public GoogleMapValuesDto GoogleMapValuesDto { get; set; } = new();
    }

    public class UpdateFamilyCommandHandler : IRequestHandler<UpdateFamilyCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateFamilyCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<UpdateFamilyCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateFamilyCommand request, CancellationToken cancellationToken)
        {

            var familty = _context.Families
                .Include(i => i.AccommodationData)
                .Include(i => i.ContactInformationData)
                .Include(i => i.FamilyRegistrationRequest)
                .ThenInclude(i=> i.FamilyNeedData)
                .Include(i => i.MonthlyIncomeData)
                .Include(i => i.ResidencyAddressData)
                .Include(i => i.ResponsibleFamilyMember.EducationalData)
                .Include(i => i.ResponsibleFamilyMember.HealthStatusData)
                .Include(i => i.ResponsibleFamilyMember.MaritalStatusData)
                .Include(i => i.ResponsibleFamilyMember.OccupationData)
                .Include(i => i.ResponsibleFamilyMember.PersonalDataForm)
                .Include(i => i.SocialSecurityData)

                .Where(w => w.objectkey == request.Objectkey)
                .FirstOrDefault();


            familty.AccommodationData.AccommodationTypeId = request.AccommodationData_AccommodationTypeId;
            familty.AccommodationData.Others = request.AccommodationData_Others;

            familty.ContactInformationData.Email = request.ContactInformation_Email;
            familty.ContactInformationData.Facebook = request.ContactInformation_Facebook;
            familty.ContactInformationData.Instagram = request.ContactInformation_Instagram;
            familty.ContactInformationData.Mobile = request.ContactInformation_Mobile;
            familty.ContactInformationData.Others = request.ContactInformation_Others;
            familty.ContactInformationData.PhoneNumber = request.ContactInformation_PhoneNumber;
            familty.ContactInformationData.Twitter = request.ContactInformation_Twitter;

            familty.FamilyRegistrationRequest.FamilyCategoryId = request.FamilyCategoryId;

            //familty.FamilyRegistrationRequest.FamilyNeedData
            await SetFamilyNeeds(request, familty);

            familty.MonthlyIncomeData.MonthlyIncomeId = request.MonthlyIncomeData_MonthlyIncomeId;

            familty.ResidencyAddressData.District = request.ResidencyAddressData_District;
            familty.ResidencyAddressData.IsOutOfTabuk = request.ResidencyAddressData_IsOutOfTabuk;
            familty.ResidencyAddressData.LocationOnTheMap = request.ResidencyAddressData_LocationOnTheMap;
            familty.ResidencyAddressData.Others = request.ResidencyAddressData_Others;
            familty.ResidencyAddressData.Province = request.ResidencyAddressData_Province;
            familty.ResidencyAddressData.ProvinceId = request.ResidencyAddressData_ProvinceId;
            familty.ResidencyAddressData.Street = request.ResidencyAddressData_Street;


            familty.ResponsibleFamilyMember.EducationalData.EducationalLevelId = request.EducationalLevelId;
            familty.ResponsibleFamilyMember.HealthStatusData.Description = request.HealthStatus_Description;
            familty.ResponsibleFamilyMember.HealthStatusData.HealthStatusId = request.HealthStatusId;
            familty.ResponsibleFamilyMember.HealthStatusData.Others = request.HealthStatus_Others;
            familty.ResponsibleFamilyMember.MaritalStatusData.MaritalStatusId = request.MaritalStatusData_StatusId;
            familty.ResponsibleFamilyMember.MaritalStatusData.Others = request.MaritalStatusData_Others;
            familty.ResponsibleFamilyMember.OccupationData.OccupationId = request.OccupationId;
            familty.ResponsibleFamilyMember.PersonalDataForm.DateOfBirth = request.DateOfBirth;
            familty.ResponsibleFamilyMember.PersonalDataForm.FamilyName = request.FamilyName;
            familty.ResponsibleFamilyMember.PersonalDataForm.FatherName = request.FatherName;
            familty.ResponsibleFamilyMember.PersonalDataForm.FirstName = request.FirstName;
            familty.ResponsibleFamilyMember.PersonalDataForm.GenderId = request.GenderId;
            familty.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName = request.GrandFatherName;
            familty.ResponsibleFamilyMember.PersonalDataForm.NationalityId = request.NationalityId;
            familty.ResponsibleFamilyMember.PersonalDataForm.PlaceOfBirth = request.PlaceOfBirth;

            familty.SocialSecurityData.AreYouABeneficiaryOfSocialSecurity = request.SocialSecurityData_AreYouABeneficiaryOfSocialSecurity;
            familty.SocialSecurityData.Description = request.SocialSecurityData_Description;

            familty.ResidencyAddressData.GoogleMapValues = _mapper.Map<GoogleMapValuesDto, GoogleMapValues>(request.GoogleMapValuesDto);
            await _context.SaveChangesAsync(cancellationToken);



            return familty.Id;
        }


        private async Task SetFamilyNeeds(UpdateFamilyCommand request, Family family)
        {
            family.FamilyRegistrationRequest.FamilyNeedData
                .ToList()
                .ForEach(e =>
                {

                    var isOldItemExistsInNewList = request.FamilyNeedIds?.Any(familyNeedId => familyNeedId == e.FamilyNeedId);
                    if (isOldItemExistsInNewList == false)
                    {
                        // remove old value
                        _context.FamilyNeedData.Remove(e);
                    }
                });

            request.FamilyNeedIds?.ForEach(familyNeedId =>
            {
                var isNewItemExistsInOldList = family.FamilyRegistrationRequest.FamilyNeedData.Any(a => a.FamilyNeedId == familyNeedId);

                if (isNewItemExistsInOldList == false)
                {
                    // add new item
                    family.FamilyRegistrationRequest.FamilyNeedData.Add(new FamilyNeedData()
                    {
                        FamilyNeedId = familyNeedId,
                    });
                }
            });
        }
    }

}
