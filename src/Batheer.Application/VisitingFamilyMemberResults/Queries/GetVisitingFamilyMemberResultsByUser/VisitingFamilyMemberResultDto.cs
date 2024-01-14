using Batheer.Application.Common.Mappings;
using Batheer.Domain;
using System;

namespace Batheer.Application.VisitingFamilyMemberResults.Queries.GetVisitingFamilyMemberResultsByUser
{
    public class VisitingFamilyMemberResultDto : IMapFrom<VisitingFamilyMemberResult>
    {
        public int Id { get; set; }
        public int FamilyMemberId { get; set; }
        public bool DidYouVisitTheFamilyMember { get; set; }
        public string GeneralNots { get; set; }
        public bool IsDeserveSupport { get; set; }
        public string WhyNoDeserveSupport { get; set; }
        public Guid ObjectKey { get; set; }

    }
}
