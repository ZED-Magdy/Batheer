using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetByAssociationsAffiliatedId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Reports.Queries.GetSummaryForAssociationsAffiliatedId
{
    public class SummaryForAssociationsAffiliatedIdDto 
    {
        public string Group_Name { get; set; }
        public string Item_Name { get; set; }
        public int Value { get; set; }
    }
}
