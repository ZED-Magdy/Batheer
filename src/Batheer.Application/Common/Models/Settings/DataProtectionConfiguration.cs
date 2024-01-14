using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Models.Settings
{
    public class DataProtectionConfiguration
    {
        public string keysFolderName { get; set; }
        public string ApplicationName { get; set; }
        public int KeyLifetime_FromDays { get; set; }
    }
}
