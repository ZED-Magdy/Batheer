using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.Common
{
    public interface ISoftDeletabe
    {
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string? DeleteNotes { get; set; }
    }
}
