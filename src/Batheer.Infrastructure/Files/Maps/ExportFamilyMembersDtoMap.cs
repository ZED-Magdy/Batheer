using Batheer.Application.Reports.Queries.ExportFamilyMembers;
using Batheer.Application.Reports.Queries.ExportFamilyRegistrationRequests;
using Batheer.Application.Reports.Queries.SearchInFamilyRegistrationRequests;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Files.Maps
{
    public class ExportFamilyMembersDtoMap : ClassMap<ExportFamilyMembersDto>
    {
        public ExportFamilyMembersDtoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);

            Map(p => p.ResponsibleFamilyMember_IdentityNo).Name("الأسرة-رقم هوية عائل الأسرة");
            Map(p => p.FamilyId)
                .Name("الأسرة-رقم التعريف");


           
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
            Map(p => p.OccupationName).Name("بيانات العمل-المهنة");

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