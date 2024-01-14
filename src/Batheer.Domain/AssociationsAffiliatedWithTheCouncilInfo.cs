using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{

    /// <summary>
    /// بيانات الجمعيات التابعة للمجلس 
    /// المزودة من قبل الجمعيات
    /// </summary>
    public class AssociationsAffiliatedWithTheCouncilInfo : AuditableEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// اسم رئيس الجمعية
        /// </summary>
        public string President_Name { get; set; }

        /// <summary>
        /// رقم رئيس الجمعية
        /// </summary>
        public string President_Mobile { get; set; }


        /// <summary>
        /// رقم نائب رئيس الجمعية
        /// </summary>
        public string VicePresident_Mobile { get; set; }


        /// <summary>
        /// اسم نائب رئيس الجمعية
        /// </summary>
        public string VicePresident_Name { get; set; }


        /// <summary>
        /// رقم مدير الجمعية
        /// </summary>
        public string Manager_Mobile { get; set; }


        /// <summary>
        /// اسم اسم الجمعية
        /// </summary>
        public string Manager_Name { get; set; }

        /// <summary>
        /// رقم الترخيص
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// تاريخ أعضاء مجلس الجمعية
        /// </summary>
        public DateTime? MembershipDate { get; set; }

        /// <summary>
        /// تاريخ الانتهاء
        /// </summary>
        public DateTime? MembershipEndDate { get; set; }

        /// <summary>
        /// عدد الموظفين
        /// </summary>
        public string EmployeesCount { get; set; }

        /// <summary>
        /// عدد أعضاء المجلس
        /// </summary>
        public string MembersCount { get; set; }

        /// <summary>
        /// عدد أعضاء الجمعية العمومية للمجلس
        /// </summary>
        public string GeneralMembersCount { get; set; }

        /// <summary>
        /// موقع الجمعية على خرائط جوجل ماب
        /// </summary>
        public string LocationOnGoogleMap { get; set; }

        /// <summary>
        /// رقم التواصل
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// البريد الالكتروني
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// رابط الموقع الالكرتوني
        /// </summary>
        public string WebsiteUrl { get; set; }


        /// <summary>
        /// نوع نشاط الجمعية
        /// </summary>
        public List<AssociationsAffiliatedWithTheCouncilInfoActivityType> ActivityTypes { get; set; } = new List<AssociationsAffiliatedWithTheCouncilInfoActivityType>();

        /// <summary>
        /// تصنيف الجمعية
        /// </summary>
        public int? ClassificationId { get; set; }
        public Classification Classification { get; set; }

        public Guid objectkey { get; set; }


        public int? TownId { get; set; }
        public Town Town { get; set; }
    }
}
