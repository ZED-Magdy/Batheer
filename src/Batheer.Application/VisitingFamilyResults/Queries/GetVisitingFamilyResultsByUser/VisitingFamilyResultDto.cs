using Batheer.Application.Common.Mappings;
using Batheer.Domain;
using System;

namespace Batheer.Application.VisitingFamilyResults.Queries.GetVisitingFamilyResultsByUser
{
    public class VisitingFamilyResultDto : IMapFrom<VisitingFamilyResult>
    {
        public int Id { get; set; }
        public int FamilyId { get; set; }
        public bool DidYouVisitTheFamily { get; set; }
        public string GeneralNots { get; set; }
        public bool IsDeserveSupport { get; set; }
        public string WhyNoDeserveSupport { get; set; }
        public Guid ObjectKey { get; set; }

    }
}
