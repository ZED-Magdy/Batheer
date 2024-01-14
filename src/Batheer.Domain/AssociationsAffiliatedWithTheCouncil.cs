using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{
    /// <summary>
    /// بيانات الجمعيات التابعة للمجلس 
    /// </summary>
    public class AssociationsAffiliatedWithTheCouncil
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AboutIt { get; set; }
        public string AdministrativeRestructuring { get; set; }
        public string ContactInformation { get; set; }
        public string LocationOnTheMap { get; set; }


        /****from excel & PDF *****/

        /// <summary>
        /// ايميل الجمعية
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// المدير التنفيذي
        /// </summary>
        public string ExecutiveDirectorName { get; set; }

        /// <summary>
        /// رقم التواصل
        /// </summary>
        public string ContactNumber { get; set; }

        public CouncilCategories CouncilCategory { get; set; }

        public Guid objectkey { get; set; }



        public enum CouncilCategories
        {
            /// <summary>
            /// جمعيات أهلية 
            /// </summary>
            Civil_Associations,

            /// <summary>
            /// لجان تنمية
            /// </summary>
            Development_Committees,

            /// <summary>
            /// جمعيات تحفيظ ومكاتب الدعوة
            /// </summary>
            Memorization_Associations_and_Advocacy_Offices

        }


        public int? AssociationsAffiliatedWithTheCouncilInfoId { get; set; }
        public AssociationsAffiliatedWithTheCouncilInfo AssociationsAffiliatedWithTheCouncilInfo { get; set; }
    }
}
