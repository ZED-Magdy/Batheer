using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class MonthlyIncomeConfiguration : IEntityTypeConfiguration<MonthlyIncome>
    {
        public void Configure(EntityTypeBuilder<MonthlyIncome> builder)
        {

           builder.HasData(
                  new MonthlyIncome() { Id = 1, Name = "لا يوجد" },
                  new MonthlyIncome() { Id = 2, Name = "1000-3000" },
                  new MonthlyIncome() { Id = 3, Name = "1000-3000" },
                  new MonthlyIncome() { Id = 4, Name = "5000-7000" },
                  new MonthlyIncome() { Id = 99, Name = "غير محدد" },
                  new MonthlyIncome() { Id = 100, Name = "أكثر من 7000" }
              );
        }
    }
}