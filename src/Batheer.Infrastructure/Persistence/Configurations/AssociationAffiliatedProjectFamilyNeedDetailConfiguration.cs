using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class AssociationAffiliatedProjectFamilyNeedDetailConfiguration : IEntityTypeConfiguration<AssociationAffiliatedProjectFamilyNeedDetail>
    {
        public void Configure(EntityTypeBuilder<AssociationAffiliatedProjectFamilyNeedDetail> builder)
        {

            builder.HasOne(o => o.AssociationAffiliatedProject)
                .WithMany(m => m.AssociationAffiliatedProjectFamilyNeedDetails)
                .HasForeignKey(f => f.AssociationAffiliatedProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.FamilyNeedDetail)
                .WithMany(m => m.AssociationAffiliatedProjectFamilyNeedDetails)
                .HasForeignKey(f => f.FamilyNeedDetailId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}