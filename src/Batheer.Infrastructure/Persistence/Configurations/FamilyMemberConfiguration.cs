using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class FamilyMemberConfiguration : IEntityTypeConfiguration<FamilyMember>
    {
        public void Configure(EntityTypeBuilder<FamilyMember> builder)
        {
            builder.HasQueryFilter(e => e.IsDeleted == false);

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

            builder.HasOne<Family>(a => a.Family)
               .WithMany(a=> a.FamilyMembers)
               .HasForeignKey(a => a.FamilyId)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}