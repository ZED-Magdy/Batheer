using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Summaries.Queries.GetLastFamiliesReceived
{
    public class LastFamiliesReceivedDto
    {
        public Guid? PersonalPhotoFileObjectKey { get; set; }
        public string FullName { get; set; }
        public string Nationality_ISO_CODES { get; set; }
        public string IdentityNo { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string TheCouncilName { get; set; }
    }
}
