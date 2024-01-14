using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Models.RequestForms
{
    public class SocialSecurityDataModel
    {
        public bool AreYouABeneficiaryOfSocialSecurity { get; set; }

        /// <summary>
        /// اسم الجمعية المسجل فيها إن وجدت
        /// </summary>
        public string Description { get; set; }
    }
}
