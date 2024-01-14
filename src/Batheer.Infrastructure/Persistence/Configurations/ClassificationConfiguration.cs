using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class ClassificationConfiguration : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
        {
            // https://es.ncnp.gov.sa/nonprofits
            builder.HasData(
                     new Classification() { Id = 1, Name = "البيئة" },
                     new Classification() { Id = 2, Name = "البيئة حماية الحيوان" },
                     new Classification() { Id = 3, Name = "التأييد والمؤازرة" },
                     new Classification() { Id = 4, Name = "التعليم والأبحاث" },
                     new Classification() { Id = 5, Name = "التنمية و الإسكان" },
                     new Classification() { Id = 6, Name = "الثقافة والترفيه" },
                     new Classification() { Id = 7, Name = "الخدمات الاجتماعية" },
                     new Classification() { Id = 8, Name = "الروابط المهنية" },
                     new Classification() { Id = 9, Name = "الصحة" },
                     new Classification() { Id = 10, Name = "منظمات الدعوة والإرشاد والتعليم الديني وخدمة ضيوف الرحمن" },
                     new Classification() { Id = 11, Name = "منظمات دعم العمل الخيري" }
                     );


            builder.HasMany(m => m.AssociationsAffiliatedWithTheCouncilInfos)
                 .WithOne(m => m.Classification)
                 .HasForeignKey(m => m.ClassificationId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}