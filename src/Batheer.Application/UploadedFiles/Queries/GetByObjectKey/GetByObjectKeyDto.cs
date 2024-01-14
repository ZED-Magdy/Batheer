using AutoMapper;
using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Batheer.Application.UploadedFiles.Queries.GetByObjectKey
{
    public class GetByObjectKeyDto : IMapFrom<Domain.UploadedFile>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }

        public Guid ObjectKey { get; set; }

        public string DefaultFilePath { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.UploadedFile, GetByObjectKeyDto>();

        }
    }
}
