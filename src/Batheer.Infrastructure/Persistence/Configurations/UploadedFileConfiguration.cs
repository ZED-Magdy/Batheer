using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.IO;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class UploadedFileConfiguration : IEntityTypeConfiguration<UploadedFile>
    {
        public void Configure(EntityTypeBuilder<UploadedFile> builder)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            //                        C:\Users\mdahman\source\repos\Tabuk_CouncilProject\src\Batheer
            var file = File.OpenRead(@$"{currentDirectory}\wwwroot\avatar.jpg");
            byte[] bytes = null;


            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                bytes = ms.ToArray();
            }

            string contentType;

            new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider()
               .TryGetContentType(file.Name, out contentType);

            builder.HasData(
                   new UploadedFile()
                   {
                       Id = 1,
                       ContentType = contentType,
                       FileName = file.Name,
                       Content = bytes,
                       ObjectKey = Guid.NewGuid(),
                   },
                    new UploadedFile()
                    {
                        Id = 2,
                        ContentType = contentType,
                        FileName = file.Name,
                        Content = bytes,
                        ObjectKey = Guid.NewGuid(),
                    },
                     new UploadedFile()
                     {
                         Id = 3,
                         ContentType = contentType,
                         FileName = file.Name,
                         Content = bytes,
                         ObjectKey = Guid.NewGuid(),
                     }
                );
        }
    }
}