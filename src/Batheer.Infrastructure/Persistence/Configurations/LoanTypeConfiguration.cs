using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class LoanTypeConfiguration : IEntityTypeConfiguration<LoanType>
    {
        public void Configure(EntityTypeBuilder<LoanType> builder)
        {

            builder.HasData(
                   new LoanType() { Id = 1, Name = "شخصية" },
                   new LoanType() { Id = 2, Name = "عقارية" },
                   new LoanType() { Id = 3, Name = "بطاقات إئتمانية" },
                   new LoanType() { Id = 4, Name = "قروض حكومية" },
                   new LoanType() { Id = 100, Name = "آخر" }
               );
        }
    }
}