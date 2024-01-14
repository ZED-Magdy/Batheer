using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Models.RequestForms
{
    public class LoanDataModel
    {
        public int LoanTypeId { get; set; }
        public string Others { get; set; }



        /// <summary>
        /// هل لديك قروض أو التزامات أخرى؟
        /// </summary>
        public bool DoYouHaveLoansOrOtherObligations { get; set; }

        public string Description { get; set; }
    }
}
