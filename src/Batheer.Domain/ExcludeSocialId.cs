using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{
    public class ExcludeIdentityNumber : AuditableEntity
    {
        public int Id { get; set; }
        public string IdentityNo { get; set; }
        public string Notes { get; set; }

    }
}
