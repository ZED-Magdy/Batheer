using Batheer.Application.Reports.Queries.SearchInFamilyRegistrationRequests;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Files.Maps
{
    public class SearchInFamilyRegistrationRequestsDtoMap : ClassMap<SearchInFamilyRegistrationRequestsDto>
    {
        public SearchInFamilyRegistrationRequestsDtoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);

            Map(p => p.CouncilProject).Name("تصنيف المشروع");
            Map(p => p.FamilyNeed_01)
                .Convert(c => c.Value.FamilyNeed_01 == "1" ? "نعم" : "لا")
                .Name("نوع الدعم_مأكل ومشرب");


            Map(p => p.FamilyNeed_02)
                .Convert(c => c.Value.FamilyNeed_02 == "1" ? "نعم" : "لا")
                .Name("نوع الدعم_ملبس");
            Map(p => p.FamilyNeed_03)
                .Convert(c => c.Value.FamilyNeed_03 == "1" ? "نعم" : "لا")
                .Name("نوع الدعم_فواتير");
            Map(p => p.FamilyNeed_04)
                .Convert(c => c.Value.FamilyNeed_04 == "1" ? "نعم" : "لا")
                .Name("نوع الدعم_مسكن");
            Map(p => p.FamilyNeed_05)
                .Convert(c => c.Value.FamilyNeed_05 == "1" ? "نعم" : "لا")
                .Name("نوع الدعم_سيولة نقدية");


            Map(p => p.FamilyNeed_06)
    .Convert(c => c.Value.FamilyNeed_06 == "1" ? "نعم" : "لا")
    .Name("نوع الدعم_صحي");
            Map(p => p.FamilyNeed_07)
                .Convert(c => c.Value.FamilyNeed_07 == "1" ? "نعم" : "لا")
                .Name("نوع الدعم_نفسي");
            Map(p => p.FamilyNeed_08)
                .Convert(c => c.Value.FamilyNeed_08 == "1" ? "نعم" : "لا")
                .Name("نوع الدعم_اجتماعي");
            Map(p => p.FamilyNeed_09)
                .Convert(c => c.Value.FamilyNeed_09 == "1" ? "نعم" : "لا")
                .Name("نوع الدعم_تطوعي");

            Map(p => p.FamilyCategoryName).Name("تصنيف الأسرة");
            Map(p => p.FirstName).Name("الاسم الأول");
            Map(p => p.FatherName).Name("اسم الأب");
            Map(p => p.GrandFatherName).Name("اسم الجد");
            Map(p => p.FamilyName).Name("اسم العائلة");
            Map(p => p.IdentityNo).Name("رقم الهوية");
            Map(p => p.DateOfBirth).Name("تاريخ الميلاد");
            Map(p => p.PlaceOfBirth).Name("مكان الميلاد");
            Map(p => p.GenderName).Name("الجنس");
            Map(p => p.NationalityName).Name("الجنسية");
            Map(p => p.IdentityFileId).Name("صورة الهوية");
            Map(p => p.PersonalPhotoFileId).Name("الصورة الشخصية");


            Map(p => p.EducationalLevelName).Name("البيانات التعليمية-المستوى الدراسي");
            Map(p => p.HealthStatusData_StatusName).Name("بيانات الحالة الصحية-الحالة الصحية");
            Map(p => p.HealthStatusData_Description).Name("بيانات الحالة الصحية-نوع المرض أو الإعاقة إن وجد");
            Map(p => p.HealthStatusData_Others).Name("بيانات الحالة الصحية-أخرى");
            Map(p => p.MaritalStatusData_StatusName).Name("الحالة الاجتماعية");
            Map(p => p.MaritalStatusData_Others).Name("الحالة الاجتماعية-أخرى");
            Map(p => p.OccupationName).Name("بيانات العمل-المهنة");




            Map(p => p.ContactInformationData_Email).Name("البريد الالكتروني");
            Map(p => p.ContactInformationData_Mobile).Name("رقم الجوال");
            Map(p => p.ContactInformationData_PhoneNumber).Name("رقم الهاتف");
            Map(p => p.ContactInformationData_Facebook).Name("فيسبوك");
            Map(p => p.ContactInformationData_Twitter).Name("تويتر");
            Map(p => p.ContactInformationData_Instagram).Name("انستجرام");
            Map(p => p.ContactInformationData_Others).Name("بيانات الاتصال-أخرى");

            Map(p => p.ResidencyAddressData_IsOutOfTabuk)
                 .Convert(c => c.Value.ResidencyAddressData_IsOutOfTabuk ? "نعم" : "لا")
                .Name("عنوان الإقامة-خارج تبوك");

            Map(p => p.ResidencyAddressData_Province).Name("عنوان الإقامة-المحافظة");
            Map(p => p.ResidencyAddressData_District).Name("عنوان الإقامة-الحي");
            Map(p => p.ResidencyAddressData_Street).Name("عنوان الإقامة-الشارع");
            Map(p => p.ResidencyAddressData_Others).Name("عنوان الإقامة-أخرى");
            Map(p => p.ResidencyAddressData_LocationOnTheMap).Name("عنوان الإقامة-الموقع على الخارطة");


            Map(p => p.AccommodationData_TypeName).Name("بيانات السكن-نوع السكن");
            Map(p => p.AccommodationData_Others).Name("بيانات السكن-أخرى");
            Map(p => p.MonthlyIncomeName).Name("الدخل الشهري");
            Map(p => p.SocialSecurityData_AreYouABeneficiaryOfSocialSecurity)
                .Convert(c => c.Value.SocialSecurityData_AreYouABeneficiaryOfSocialSecurity ? "نعم" : "لا")
                //.TypeConverter<MyBooleanConverter>()
                .Name("بيانات الضمان الاجتماعي-هل أنت من مستفيدي الضمان الاجتماعي");

            Map(p => p.SocialSecurityData_Description).Name("بيانات الضمان الاجتماعي-اسم الجمعية المسجل فيها إن وجد");
            Map(p => p.AssociationsAffiliatedWithTheCouncilName).Name("اسم الجهة");


        }
    }
}