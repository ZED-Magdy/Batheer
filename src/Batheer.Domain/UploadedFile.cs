using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{
    public class UploadedFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public string DefaultFilePath { get; set; }

        public Guid ObjectKey { get; set; } = Guid.NewGuid();
    }
}
