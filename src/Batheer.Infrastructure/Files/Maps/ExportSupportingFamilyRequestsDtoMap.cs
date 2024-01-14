using Batheer.Application.Reports.Queries.ExportSupportingFamilyRequests;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace Batheer.Infrastructure.Files.Maps
{
    public class ExportSupportingFamilyRequestsDtoMap : ClassMap<ExportSupportingFamilyRequestsDto>
    {
        public ExportSupportingFamilyRequestsDtoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);

            Map(p => p.ResponsibleFamilyMember_IdentityNo).Name("الأسرة-رقم هوية عائل الأسرة");
            Map(p => p.FamilyId)
                .Name("الأسرة-رقم التعريف");


           
            Map(p => p.SupportingFamilyTypeName).Name("نوع الطلب");
            
            Map(p => p.BankDefaultData_IsThereABankDefault).Name("البنوك-هل يوجد تعثر لأحد البنوك؟");
            Map(p => p.ProjectData_WhatAreTheObstaclesFacingTheProject).Name("بيانات التمويل-ما نوع التمويل الذي ترغب به؟");
            
            Map(p => p.FinanceData_FinanceTypeName).Name("بيانات التمويل-نوع التمويل");
            Map(p => p.FinanceData_ProducedFamilyProductName).Name("بيانات التمويل-أسر منتجة");
            
            Map(p => p.LoanData_DoYouHaveLoansOrOtherObligations).Name("بيانات القروض-هل لديك قروض أو التزامات أخرى؟");
            Map(p => p.LoanData_Others).Name("بيانات القروض- أخرى");
            Map(p => p.LoanData_LoanTypeName).Name("بيانات القروض-نوع القرض");
            Map(p => p.LoanData_Description).Name("بيانات القروض-تفصيل القرض");



            Map(p => p.ProjectData_EstimatedProjectCostName).Name("بيانات المشروع-التكلفة التقديرية للمشروع");
            Map(p => p.ProjectData_Others).Name("بيانات المشروع-أخرى");
            Map(p => p.ProjectData_AboutTheProject).Name("بيانات المشروع-نبذة عن المشروع");
            Map(p => p.ProjectData_WhatAreTheObstaclesFacingTheProject).Name("بيانات المشروع-العوائق التي تقابل المشروع");

            Map(p => p.WorkOnAProjectData_AreYouFreeAndReadyToWorkOnAproject).Name("العمل على مشروع-هل أنت متفرغ وعلى استعداد للعمل على مشروع؟");
           


            Map(p => p.AssociationsAffiliatedWithTheCouncilName).Name("اسم الجهة");

        }


        class MyBooleanConverter : DefaultTypeConverter
        {
            public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            {
                if (value == null)
                {
                    return "لا";
                }
                var boolValue = (bool)value;
                return boolValue ? "نعم" : "لا";
            }
        }
    }
}