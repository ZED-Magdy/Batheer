using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Summaries.Queries.GetProjectsProgress
{
    public class ProgressDto
    {
        public string Title { get; set; }
        public int Value { get; set; }
        public int Progres { get; set; }

        public string TheCouncilName { get; set; }
    }
}
