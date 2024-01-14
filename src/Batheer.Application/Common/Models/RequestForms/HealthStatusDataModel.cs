using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Models.RequestForms
{
    public class HealthStatusDataModel
    {
        public int HealthStatusId { get; set; }
        public string Others { get; set; }

        /// <summary>
        /// نوع المرض أو الإعاقة إن وجد
        /// </summary>
        public string Description { get; set; }
    }
}
