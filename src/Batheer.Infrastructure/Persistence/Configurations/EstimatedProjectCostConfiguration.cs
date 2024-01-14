using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class EstimatedProjectCostConfiguration : IEntityTypeConfiguration<EstimatedProjectCost>
    {
        public void Configure(EntityTypeBuilder<EstimatedProjectCost> builder)
        {

            builder.HasData(
                   new EstimatedProjectCost() { Id = 1, Name = "3000- 5000" },
                   new EstimatedProjectCost() { Id = 2, Name = "5000- 7000" },
                   new EstimatedProjectCost() { Id = 3, Name = "7000- 10000" },
                   new EstimatedProjectCost() { Id = 100, Name = "آخر" }
               );
        }
    }
}