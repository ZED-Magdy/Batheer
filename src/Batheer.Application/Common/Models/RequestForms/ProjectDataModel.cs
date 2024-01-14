﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Models.RequestForms
{
    public class ProjectDataModel
    {
        public int EstimatedProjectCostId { get; set; }

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
