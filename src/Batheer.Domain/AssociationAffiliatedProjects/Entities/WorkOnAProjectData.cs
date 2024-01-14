using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class WorkOnAProjectData : AuditableEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// هل أنت متفرغ وعلى استعداد للعمل على مشروع؟
        /// </summary>
        public bool AreYouFreeAndReadyToWorkOnAproject { get; set; }
    }
}
