using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class FamilyRegistrationRequestConfiguration : IEntityTypeConfiguration<FamilyRegistrationRequest>
    {
        public void Configure(EntityTypeBuilder<FamilyRegistrationRequest> builder)
        {
            builder.HasKey(p => p.Id);


            builder.HasOne<CouncilProject>(a => a.CouncilProject)
                .WithMany(m => m.FamilyRegistrationRequests)
                .HasForeignKey(a => a.CouncilProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne<Family>(a => a.Family)
            //   .WithMany()
            //   .HasForeignKey(a => a.FamilyId)
            //   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Family>(a => a.Family)
                .WithOne(a => a.FamilyRegistrationRequest)
                .HasForeignKey<FamilyRegistrationRequest>(a => a.FamilyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<FamilyCategory>(a => a.FamilyCategory)
               .WithMany()
               .HasForeignKey(a => a.FamilyCategoryId)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(m => m.FamilyNeedData)
                .WithOne()
                .HasForeignKey(f => f.FamilyRegistrationRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany<TheIntendedBeneficiariesOfTheScheduledAssociationProject>(a => a.TheIntendedBeneficiariesOfTheScheduledAssociationProjects)
            //    .WithOne(o=> o.FamilyRegistrationRequest)
            //    .HasForeignKey(a => a.FamilyRegistrationRequestId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}