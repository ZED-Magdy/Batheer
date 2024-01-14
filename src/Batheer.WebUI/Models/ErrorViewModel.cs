using System;

namespace Batheer.WebUI.Models
{
    public class ErrorViewModel
    {
        public string BaseRequestId { get; set; }

        public bool ShowBaseRequestId => !string.IsNullOrEmpty(BaseRequestId);
    }
}
