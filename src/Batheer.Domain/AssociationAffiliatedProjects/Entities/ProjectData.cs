using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class ProjectData : AuditableEntity
    {
        public int Id { get; set; }
       

        public int EstimatedProjectCostId { get; set; }
        public virtual Lookups.EstimatedProjectCost EstimatedProjectCost { get; set; }

        public string Others { get; set; }


        /// <summary>
        /// نبذة عن المشروع
        /// </summary>
        public string AboutTheProject { get; set; }

        /// <summary>
        /// ما العوائق التي تقابل المشروع؟
        /// </summary>
        public string WhatAreTheObstaclesFacingTheProject { get; set; }
    }
}
