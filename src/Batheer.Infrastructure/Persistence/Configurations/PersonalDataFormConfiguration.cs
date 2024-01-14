using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class PersonalDataFormConfiguration : IEntityTypeConfiguration<PersonalDataForm>
    {
        public void Configure(EntityTypeBuilder<PersonalDataForm> builder)
        {

            builder.HasOne<UploadedFile>(o => o.PersonalPhotoFile)
                .WithMany()
                .HasForeignKey(f => f.PersonalPhotoFileId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne<UploadedFile>(o => o.IdentityFile)
                .WithMany()
                .HasForeignKey(f => f.IdentityFileId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany<>(a => a.BaseRequests)
            //    .WithOne(m => m.PersonalDataForm)
            //    .HasForeignKey(a => a.PersonalDataFormId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}