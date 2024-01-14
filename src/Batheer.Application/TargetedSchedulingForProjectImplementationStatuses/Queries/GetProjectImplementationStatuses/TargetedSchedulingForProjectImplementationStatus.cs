using AutoMapper;
using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.TargetedSchedulingForProjectImplementationStatuses.Queries.GetProjectImplementationStatuses
{
    public class TargetedSchedulingForProjectImplementationStatus : IMapFrom<Domain.TargetedSchedulingForProjectImplementationStatus>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
