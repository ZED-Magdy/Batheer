using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class NationalityConfiguration : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {

            builder.HasData(
                   new Nationality() { Id = 1, Name = "السعودية", ISO_CODES = "sa" },
                   new Nationality() { Id = 2, Name = "اليمن", ISO_CODES = "ye" },
                   new Nationality() { Id = 3, Name = "مصر", ISO_CODES = "eg" },
                   new Nationality() { Id = 4, Name = "الأردن", ISO_CODES = "jo" },
                   new Nationality() { Id = 5, Name = "سوريا", ISO_CODES = "sy" },
                    new Nationality() { Id = 999, Name = "غير محدد", ISO_CODES = "" }
                   );
        }
    }
}