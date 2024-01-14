using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class FinanceTypeConfiguration : IEntityTypeConfiguration<FinanceType>
    {
        public void Configure(EntityTypeBuilder<FinanceType> builder)
        {

            builder.HasData(
                   new FinanceType() { Id = 1, Name = "سيارات الأجرة" },
                   new FinanceType() { Id = 2, Name = "عربات البيع" },
                   new FinanceType() { Id = 3, Name = "الأكشاك" },
                   new FinanceType() { Id = 4, Name = "الكورنرات" },
                   new FinanceType() { Id = 5, Name = "الأسر المنتجة" },
                   new FinanceType() { Id = 6, Name = "توطين المتاجر" }
               );
        }
    }
}