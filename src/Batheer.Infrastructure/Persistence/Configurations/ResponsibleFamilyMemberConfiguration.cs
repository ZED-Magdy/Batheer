using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class ResponsibleFamilyMemberConfiguration : IEntityTypeConfiguration<ResponsibleFamilyMember>
    {
        public void Configure(EntityTypeBuilder<ResponsibleFamilyMember> builder)
        {
            builder.HasKey(p => p.Id);

       
            builder.HasOne<PersonalDataForm>(a => a.PersonalDataForm)
                .WithMany()
                .HasForeignKey(a => a.PersonalDataFormId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<HealthStatusData>(a => a.HealthStatusData)
               .WithMany()
               .HasForeignKey(a => a.HealthStatusDataId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<EducationalData>(a => a.EducationalData)
               .WithMany()
               .HasForeignKey(a => a.EducationalDataId)
               .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<MaritalStatusData>(a => a.MaritalStatusData)
               .WithMany()
               .HasForeignKey(a => a.MaritalStatusDataId)
               .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<OccupationData>(a => a.OccupationData)
               .WithMany()
               .HasForeignKey(a => a.OccupationDataId)
               .OnDelete(DeleteBehavior.Restrict); 
            
            //builder.HasOne<Family>(a => a.Family)
            //   .WithMany()
            //   .HasForeignKey(a => a.FamilyId)
            //   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}