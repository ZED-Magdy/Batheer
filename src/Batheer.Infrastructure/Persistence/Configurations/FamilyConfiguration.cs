using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.HasKey(p => p.Id);

       
            builder.HasOne<ResponsibleFamilyMember>(a => a.ResponsibleFamilyMember)
                .WithMany()
                .HasForeignKey(a => a.ResponsibleFamilyMemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<ContactInformationData>(a => a.ContactInformationData)
               .WithMany()
               .HasForeignKey(a => a.ContactInformationId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<ResidencyAddressData>(a => a.ResidencyAddressData)
               .WithMany()
               .HasForeignKey(a => a.ResidencyAddressDataId)
               .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<AccommodationData>(a => a.AccommodationData)
               .WithMany()
               .HasForeignKey(a => a.AccommodationDataId)
               .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<MonthlyIncomeData>(a => a.MonthlyIncomeData)
               .WithMany()
               .HasForeignKey(a => a.MonthlyIncomeDataId)
               .OnDelete(DeleteBehavior.Restrict); 
            
            builder.HasOne<SocialSecurityData>(a => a.SocialSecurityData)
               .WithMany()
               .HasForeignKey(a => a.SocialSecurityDataId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<FamilyMember>(a => a.FamilyMembers)
                .WithOne(o=> o.Family)
                .HasForeignKey(a => a.FamilyId)
                .OnDelete(DeleteBehavior.NoAction);




            //builder.HasMany<FamilyRegistrationRequest>()
            //  .WithOne(a=> a.Family)
            //  .HasForeignKey(a => a.FamilyId)
            //  .OnDelete(DeleteBehavior.Restrict);


    


        }
    }
}