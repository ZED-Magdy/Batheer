using Batheer.Application.Reports.Queries.SearchInFamilyRegistrationRequests;
using Batheer.Application.Reports.Queries.SearchInSupportingFamilyRequests;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Files.Maps
{
    public class SearchInSupportingFamilyRequestsDtoMap : ClassMap<SearchInSupportingFamilyRequestsDto>
    {
        public SearchInSupportingFamilyRequestsDtoMap()
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
            Map(p => p.IsThereABankDefault).Name("هل يوجد تعثر لأحد البنوك؟");
            Map(p => p.FinanceTypeName).Name("نوع التمويل المرغوب");
            Map(p => p.ProducedFamilyProductName).Name("نوع الأسرة المنتجة");
            Map(p => p.DoYouHaveLoansOrOtherObligations).Name("هل يوجد قروض أو التزامات؟");
            Map(p => p.LoanTypeName).Name("نوع القرض");
            Map(p => p.EstimatedProjectCostName).Name("التكلفة التقديرية للمشروع");
            Map(p => p.AreYouFreeAndReadyToWorkOnAproject).Name("متفرغ وعلى استعداد للعمل على مشروع؟");

            //Map(p => p.AccommodationTypeName).Ignore();
            //Map(p => p.HasSupportingFamilyRequest).Ignore();
            //Map(p => p.FamilyMemberTypeName).Ignore();
            //Map(p => p.PersonalPhotoFileObjectKey).Ignore();
            //Map(p => p.PersonalPhotoFileObjectKey).Ignore();
            //Map(p => p.FamilyNeedName).Ignore();
        }
    }
}