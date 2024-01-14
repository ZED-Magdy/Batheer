using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class CouncilProjectConfiguration : IEntityTypeConfiguration<CouncilProject>
    {
        public void Configure(EntityTypeBuilder<CouncilProject> builder)
        {

            builder.HasMany<FamilyRegistrationRequest>(a => a.FamilyRegistrationRequests)
                .WithOne(m => m.CouncilProject)
                .HasForeignKey(a => a.CouncilProjectId)
                .OnDelete(DeleteBehavior.Restrict);



            builder.HasData(
                      new CouncilProject()
                      {
                          Id = 1,
                          Name = "دعم الأسر"
                      },
                      new CouncilProject()
                      {
                          Id = 2,
                          Name = "تمكين الأسر"
                      }
                      );
        }
    }
}