using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class OccupationConfiguration : IEntityTypeConfiguration<Occupation>
    {
        public void Configure(EntityTypeBuilder<Occupation> builder)
        {

            builder.HasData(
                   new Occupation() { Id = 1, Name = "موظف حكومي" },
                   new Occupation() { Id = 2, Name = "قطاع خاص" },
                   new Occupation() { Id = 3, Name = "طالب / طالبة" },
                   new Occupation() { Id = 4, Name = "متقاعد/ متقاعدة" },
                   new Occupation() { Id = 5, Name = "غير موظف" },
                   new Occupation() { Id = 99, Name = "غير محدد" }
                   );
        }
    }
}