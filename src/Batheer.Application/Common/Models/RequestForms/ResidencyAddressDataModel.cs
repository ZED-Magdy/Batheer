using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Models.RequestForms
{
    public class ResidencyAddressDataModel
    {
        public bool IsOutOfTabuk { get; set; }
        public int? ProvinceId { get; set; }
        public string Province { get; set; }

        public string District { get; set; }
        public string Street { get; set; }
        public string Others { get; set; }
        public string LocationOnTheMap { get; set; }
    }
}
