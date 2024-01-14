using Batheer.Application.Reports.Queries.SearchInFamilies;
using CsvHelper.Configuration;
using System.Globalization;

namespace Batheer.Infrastructure.Files.Maps
{
    public class SearchInFamiliesDtoMap : ClassMap<SearchInFamiliesDto>
    {
        public SearchInFamiliesDtoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            //Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");

            Map(p => p.FullName).Name("اسم المستفيد");
            Map(p => p.IdentityNo).Name("رقم الهوية");
            Map(p => p.GenderName).Name("الجنس");
            Map(p => p.NationalityName).Name("الجنسية");
            Map(p => p.Email).Name("البريد الالكتروني");
            Map(p => p.Mobile).Name("رقم الجوال");
            Map(p => p.PhoneNumber).Name("رقم الهاتف");
            Map(p => p.MaritalStatusName).Name("الحالة الاجتماعية لعائل الأسرة");
            Map(p => p.EducationalLevelName).Name("المستوى الدراسي لعائل الأسرة");
            Map(p => p.HealthStatusName).Name("الحالة الصحية");
            Map(p => p.OccupationName).Name("المهنة");
            Map(p => p.MonthlyIncomeName).Name("الدخل الشهري");
            Map(p => p.AssociationsAffiliatedWithTheCouncilName).Name("الجمعية");
            Map(p => p.FamilyCategoryName).Name("تصنيف الأسرة");
            
            
            Map(p => p.AccommodationTypeName).Name("نوع السكن");
            Map(p => p.HasSupportingFamilyRequest).Name("تمكين الأسر؟");
            Map(p => p.FamilyMemberTypeName).Name("نوعه بالعائلة");
            Map(p => p.PersonalPhotoFileObjectKey).Ignore();
            Map(p => p.FamilyNeedName).Name("نوع الدعم");


        }
    }
}